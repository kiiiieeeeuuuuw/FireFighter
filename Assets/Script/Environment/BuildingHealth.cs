using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public float Health;
    public GameObject BuildingCrack;

    public void Damage()
    {
        Health -= 25;
    }
}
