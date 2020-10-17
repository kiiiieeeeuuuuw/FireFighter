using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSpawner : MonoBehaviour
{
    public GameObject Crack;
    private Transform[] Locs;

    private const int TL = 0;
    private const int TR = 1;
    private const int BL = 2;
    private const int BR = 3;
    // Start is called before the first frame update
    void Start()
    {
        Locs = new Transform[4];


        /*foreach (Transform t in transform)
        {
            if (t.name.ToLower().Contains("glow"))
                Glows.Add(t.gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
