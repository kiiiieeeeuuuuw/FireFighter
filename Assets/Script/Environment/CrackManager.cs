using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrackManager : MonoBehaviour
{
    public ParticleSystem LeftDebreeEffect;
    public ParticleSystem RightDebreeEffect;

    private List<GameObject> Cracks;

    private void Awake()
    {
        Cracks = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {        
        foreach (Transform t in transform)
        {
            if (t.name.ToLower().Contains("crack"))            
                Cracks.Add(t.gameObject);            
        }
        SpawnDebree();
    }

    public void InCreaseCrack()
    {
        try
        {
            bool deepenedCrack = false;
            foreach (var crack in Cracks)
            {
                if (crack.name.Contains("1") && !crack.activeSelf)
                {
                    crack.SetActive(true);
                    deepenedCrack = true;
                    break;
                }
                else
                {
                    if (crack.name.Contains("2") && !crack.activeSelf)
                    {
                        crack.SetActive(true);
                        deepenedCrack = true;
                        break;
                    }
                }
            }

            if (deepenedCrack)
            {
                SpawnDebree();
            }
        }

        catch (NullReferenceException exce)
        {
            Debug.LogError(exce.Message);
        }
    }

    public void SpawnDebree()
    {
        if (transform.localScale.x > 0)        
            Instantiate(RightDebreeEffect, transform.position, Quaternion.identity);        
        else        
            Instantiate(LeftDebreeEffect, transform.position, Quaternion.identity);        
    }
}
