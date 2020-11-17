using System;
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


    [SerializeField]
    private float CurrentHealth;
    [SerializeField]
    private List<ThresholdTracker> CrackSpawnThresholds;
    private double UpperCrackHealth;
    private double LowerCrackHealth;
    private List<ThresholdTracker> CrackIncreaseThresholds;
    private bool broken;
    private Animator BuildingAC;

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
    }

    public void Update()
    {
        foreach(Transform t in transform)
        {
            if (t.name.Contains("Ember"))
            {
                Damage(t.gameObject.GetComponent<DoesDamage>().GetDamage() * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {            
            Damage(collision.gameObject.GetComponent<DoesDamage>().GetDamage());
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth > 0)
        {
            BuildingAC.SetTrigger("Hit");
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
}
