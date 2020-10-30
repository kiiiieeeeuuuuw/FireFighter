using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public const float StartHealth = 400;
    public GameObject CrackManager;    
    
    [SerializeField]
    private float CurrentHealth;
    private List<CrackThreshold> CrackThresholds;

    private class CrackThreshold
    {
        public double Threshold { get; set; }
        public bool Passed { get; set; }

        public CrackThreshold(double threshhold)
        {
            Threshold = threshhold;
            Passed = false;
        }
    }

    public void Start()
    {
        CurrentHealth = StartHealth;

        CrackThresholds = new List<CrackThreshold>(){
            new CrackThreshold(StartHealth),
            new CrackThreshold(StartHealth * 3/4),
            new CrackThreshold(StartHealth * 2/4)            
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {            
            Damage(collision.gameObject.GetComponent<DoesDamage>().GetDamage());
        }
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        bool triggered = false;
        int i = 0;
        while(i < CrackThresholds.Count && !triggered)
        {
            if (CrackThresholds[i].Passed == false && CrackThresholds[i].Threshold > CurrentHealth)
            {
                CrackManager.GetComponent<CrackSpawner>().SpawnCrack();
                CrackThresholds[i].Passed = true;
                triggered = true;
            }
            else
            {
                CrackManager.GetComponent<CrackSpawner>().InCreaseCrack();
                triggered = true;
            }
            
            i++;
        }
            
    }
}
