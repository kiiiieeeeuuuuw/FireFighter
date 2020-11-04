using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingComponent : MonoBehaviour
{
    public int minXForce;
    public int maxXForce;
    public int yForce;
    public int direction;
    public float aliveTime;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var rng = new System.Random();
        var xForce = rng.Next(minXForce, maxXForce);
        var next = rng.Next(0, 11);
        rb.AddForce(new Vector2(xForce * direction, yForce));
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveTime < 0)
            Destroy(gameObject);
        else
            aliveTime -= Time.deltaTime;
    }
}
