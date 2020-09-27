using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActiveFires : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] CleanupFires;

    public float activeFires;
    public int CameraIndex;

    public float currentDelta;
    public float leftDelta;
    public float rightDelta;
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

        // Get fire closest to camera
        CameraIndex = 0;
        float xVal = CleanupFires[CameraIndex].transform.position.x;
        while(xVal < camera.transform.position.x)
        {
            xVal = CleanupFires[CameraIndex].transform.position.x;
            CameraIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*float cameraX = camera.transform.position.x;
        currentDelta =  cameraX - CleanupFires[CameraIndex].transform.position.x;
        leftDelta = cameraX - CleanupFires[CameraIndex - 1].transform.position.x;
        rightDelta = cameraX - CleanupFires[CameraIndex + 1].transform.position.x;

        if (currentDelta < rightDelta)
            CameraIndex++;
        else if (currentDelta < leftDelta)
            CameraIndex--;*/
    }
}
