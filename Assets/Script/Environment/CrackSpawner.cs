using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public class CrackSpawner : MonoBehaviour
{
    public GameObject Crack;    

    private Vector2[] LocsLeft;
    private Vector2[] LocsRight;
    private List<GameObject> SpawnedCracks;
    private GameObject LastSpawned;
    private int xScale;

    private const int TL = 0;
    private const int TR = 0;
    private const int BL = 1;
    private const int BR = 1;
    // Start is called before the first frame update
    void Start()
    {
        LocsLeft = new Vector2[2];
        LocsRight = new Vector2[2];
        foreach (Transform t in transform)
        {
            string name = t.name;
            switch (name)
            {
                case "LocTopLeft":
                    LocsLeft[TL] = t.position;
                    break;
                case "LocTopRight":
                    LocsRight[TR] = t.position;
                    break;
                case "LocBottomLeft":
                    LocsLeft[BL] = t.position;
                    break;
                case "LocBottomRight":
                    LocsRight[BR] = t.position;
                    break;
            }
        }

        SpawnedCracks = new List<GameObject>();
    }

    public void TriggerCrack(int index)
    {
        if (SpawnedCracks.Count < index + 1)
            SpawnCrack();
        else
            InCreaseCrack();
    }

    public void SpawnCrack()
    {
        if (SpawnedCracks.Count < 3)
        {
            // Determine side of building
            var rng = new System.Random();
            var side = rng.Next(2);
            Vector2[] loc;

            if (SpawnedCracks.Count == 0)
            {
                xScale = 1;
                if (side == 0)
                {
                    loc = LocsLeft;
                    xScale = -1;
                }
                else
                    loc = LocsRight;
            }
            else
            {
                xScale *= -1;
                loc = xScale > 0 ? LocsRight : LocsLeft;
            }


            // Determine location
            var top = (int)loc[TL].y;
            var bottom = (int)loc[BR].y;
            var yPos = rng.Next(bottom, top);
            var xPos = loc[TL].x;

            // Spawn crack with correct scale and rotation
            LastSpawned = Instantiate(Crack, new Vector2(xPos, yPos), Quaternion.identity, transform);
            var rootScale = transform.parent.localScale;
            var crackScale = LastSpawned.transform.localScale;
            LastSpawned.transform.localScale = new Vector3((crackScale.x / rootScale.x) * xScale, crackScale.y / rootScale.y, crackScale.z / rootScale.z);

            SpawnedCracks.Add(LastSpawned);
        }
    }

    public void InCreaseCrack()
    {
        LastSpawned.GetComponent<CrackManager>().InCreaseCrack();
    }
}
