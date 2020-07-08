using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFire : MonoBehaviour
{
    public int NumberOfSpawns;

    public GameObject Flame;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfSpawns; i++)
        {
            Instantiate(Flame, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
