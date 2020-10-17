using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSpawner : MonoBehaviour
{
    public GameObject Crack;
    private Vector2[] Locs;

    private const int TL = 0;
    private const int TR = 1;
    private const int BL = 2;
    private const int BR = 3;
    // Start is called before the first frame update
    void Start()
    {
        Locs = new Vector2[4];
        foreach (Transform t in transform)
        {
            string name = t.name;
            switch (name)
            {
                case "LocTopLeft":
                    Locs[TL] = t.position;
                    break;
                case "LocTopRight":
                    Locs[TR] = t.position;
                    break;
                case "LocBottomLeft":
                    Locs[BL] = t.position;
                    break;
                case "LocBottomRight":
                    Locs[BR] = t.position;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCrack()
    {

    }
}
