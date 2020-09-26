using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActiveFires : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] CleanupFires;

    public float activeFires;

    // Start is called before the first frame update
    void Start()
    {
        // Collect all fires
        int k = 0;
        int numberOfFires = transform.childCount;
        CleanupFires = new GameObject[numberOfFires];
        foreach(Transform t in transform)
        {
            CleanupFires[k] = t.gameObject;
            k++;
        }                

        // Sort them based upon x coordinates
        for(int i = 1; i < numberOfFires; i++)
        {
            var h = CleanupFires[i];
            int j = i - 1;
            while(j >= 0 && h.transform.position.x < CleanupFires[j].transform.position.x)
            {
                CleanupFires[j + 1] = CleanupFires[j];
                j--;
            }
            CleanupFires[j + 1] = h;
        }
        
        // Get Camera bounds
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
