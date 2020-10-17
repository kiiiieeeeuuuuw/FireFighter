using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public const float StartHealth = 400;
    public float CurrentHealth;
    public GameObject BuildingCrack;
    public List<GameObject> SpawnedBCs;

    public void Start()
    {
        CurrentHealth = StartHealth;
    }

    public void Damage()
    {
        CurrentHealth -= 25;

        if(CurrentHealth < StartHealth * (3 / 4))
        {

        }
        else if(CurrentHealth < StartHealth * (1 / 2))
        {

        }
        else if(CurrentHealth < StartHealth * (1 / 4))
        {

        }
        else if(CurrentHealth == 0)
        {

        }
            
    }
}
