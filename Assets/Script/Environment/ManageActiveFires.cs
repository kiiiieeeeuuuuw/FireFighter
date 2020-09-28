using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActiveFires : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject Player;
    public float ActiveFiresEachSideOfMiddle;


    private GameObject[] CleanupFires;
    private Dictionary<string, int> FireNameIndex;    
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
        // Store them for easy handling and find closest fire at start
        float distance = float.MaxValue;
        int closest = 0;
        FireNameIndex = new Dictionary<string, int>();
        for (int i = 0; i < numberOfFires; i++)
        {
            FireNameIndex.Add(CleanupFires[i].name, i);

            // Check which one is closest
            var distanceI = Vector2.Distance(Player.transform.position, CleanupFires[i].transform.position);
            if (distanceI < distance)
            {
                distance = distanceI;
                closest = i;
            }
        }

        // Disable outer fires
        ChangeMiddleFire(CleanupFires[closest].name);        
    }

    // Enable or disable fires based on name of fire
    public void ChangeMiddleFire(string name)
    {
        var middle = FireNameIndex[name];
        
        for(int i = 0; i < CleanupFires.Length; i++)
        {
            if (i < middle - ActiveFiresEachSideOfMiddle || i > middle + ActiveFiresEachSideOfMiddle)
                CleanupFires[i].SetActive(false);
            else CleanupFires[i].SetActive(true);
        }
    }
}
