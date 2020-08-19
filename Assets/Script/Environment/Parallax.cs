using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPosX, length;
    private Vector3 startPos;
    public GameObject cam;
    public float parallaxEffect_X;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        float dist_x = cam.transform.position.x * parallaxEffect_X;        
        float dist_y = cam.transform.position.y * parallaxEffect_X;
        var temp = new Vector3(startPosX + dist_x, transform.position.y + dist_y, transform.position.z);
        transform.position = Vector3.Lerp(startPos, temp, 0.5f);
    }
}
