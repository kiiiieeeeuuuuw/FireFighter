using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFire : MonoBehaviour
{
    public int NumberOfSpawns;

    public GameObject Flame;

    public float xForce;
    public float yForce;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfSpawns; i++)
        {
            Instantiate(Flame, transform.position, Quaternion.identity);
            var rb = Flame.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
