using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrackManager : MonoBehaviour
{
    private List<GameObject> Cracks;
    // Start is called before the first frame update
    void Start()
    {
        Cracks = new List<GameObject>();
        foreach (Transform t in transform)
        {
            if (t.name.ToLower().Contains("crack"))
            {
                Cracks.Add(t.gameObject);
            }
        }
    }

    public void InCreaseCrack()
    {
        foreach(var crack in Cracks)
        {
            if(crack.name.Contains("1") && !crack.activeSelf)
            {
                crack.SetActive(true);
                break;
            }
            if (crack.name.Contains("2") && !crack.activeSelf)
            {
                crack.SetActive(true);
                break;
            }
        }
    }
}
