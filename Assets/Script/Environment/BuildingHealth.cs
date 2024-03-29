﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public float StartHealth = 400;
    public GameObject CrackManager;
    public GameObject Building;
    public GameObject CollapsableBuilding;
    public GameObject SpriteObject;
    public float HitAnimationInterval;


    [SerializeField]
    private float CurrentHealth;
    [SerializeField]
    private List<ThresholdTracker> CrackSpawnThresholds;
    private double UpperCrackHealth;
    private double LowerCrackHealth;
    private List<ThresholdTracker> CrackIncreaseThresholds;
    private bool broken;
    private Animator BuildingAC;
    private float CurrentTime;

    private class ThresholdTracker
    {
        public double Threshold { get; set; }
        public bool Passed { get; set; }

        public ThresholdTracker(double threshhold)
        {
            Threshold = threshhold;
            Passed = false;
        }
    }

    public void Start()
    {
        CurrentHealth = StartHealth;

        CrackSpawnThresholds = new List<ThresholdTracker>(){
            new ThresholdTracker(StartHealth),
            new ThresholdTracker(StartHealth * 3/4),
            new ThresholdTracker(StartHealth * 2/4)            
        };

        BuildingAC = SpriteObject.GetComponent<Animator>();

        CurrentTime = 0;
    }

    public void Update()
    {
        foreach(Transform t in transform)
        {
            if (t.name.Contains("Ember") && !t.GetComponent<ExtinguishFlame>().Doused)
            {                
                Damage(t.gameObject.GetComponent<DoesDamage>().GetDamage() * Time.deltaTime);
            }
        }

        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Contains("Meteor"))
        {            
            Damage(collision.gameObject.GetComponent<DoesDamage>().GetDamage());
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth > 0)
        {
            if (CurrentTime <= 0)
            {
                string trigger = "Hit";
                if (CurrentHealth > 3f / 4f * StartHealth)
                    trigger += "3Q";
                else if (CurrentHealth > 2f / 4f * StartHealth)
                    trigger += "2Q";
                else if (CurrentHealth > 1f / 4f * StartHealth)
                    trigger += "1Q";
                else
                    trigger += "0Q";
                BuildingAC.SetTrigger(trigger);
                CurrentTime = HitAnimationInterval;
            }
            bool triggered = false;
            int i = 0;
            while (i < CrackSpawnThresholds.Count && !triggered)
            {
                if (CrackSpawnThresholds[i].Passed == false && CrackSpawnThresholds[i].Threshold > CurrentHealth)
                {
                    CrackManager.GetComponent<CrackSpawner>().SpawnCrack();
                    CrackSpawnThresholds[i].Passed = true;
                    // init crack tracker
                    UpperCrackHealth = CrackSpawnThresholds[i].Threshold;
                    LowerCrackHealth = i+1 < CrackSpawnThresholds.Count? CrackSpawnThresholds[i+1].Threshold : 0;
                    CrackIncreaseThresholds = new List<ThresholdTracker>()
                    {
                        new ThresholdTracker((UpperCrackHealth - LowerCrackHealth) * 2/3 + LowerCrackHealth),
                        new ThresholdTracker((UpperCrackHealth - LowerCrackHealth) * 1/3 + LowerCrackHealth)
                    };
                }
                else if(CrackIncreaseThresholds != null)
                {
                    for(int j = 0; j < CrackIncreaseThresholds.Count; j++)
                    {
                        if (CrackSpawnThresholds[j].Passed == false && CrackSpawnThresholds[j].Threshold > CurrentHealth)
                        {
                            CrackManager.GetComponent<CrackSpawner>().InCreaseCrack();
                        }
                    }                                        
                }

                i++;
            }
        }
        else if(!broken)
        {
            Instantiate(CollapsableBuilding, transform.position, Quaternion.identity);
            broken = true;
            Building.GetComponent<DestroyGameObject>().DestroyObject();
        }
            
    }

    public void Repair()
    {
        CurrentHealth = StartHealth;
    }
}
