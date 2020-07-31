using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{        

    public float xForce;
    public float yForce;

    public bool apply;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (apply)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
            apply = false;
        }

    }
}
