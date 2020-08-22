using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject FireBall;

    public GenerateBuilding Gb;
    public List<GameObject> Targets;

    public float MaxTime;
    private float PassedTime;

    public float MeteorForce;

    // Start is called before the first frame update
    void Start()
    {
        Targets = Gb.GetBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        PassedTime += Time.deltaTime;
        if(PassedTime > MaxTime && Targets.Count > 0)
        {
            var fb = Instantiate(FireBall, transform.position, Quaternion.identity);

            var rng = new System.Random();
            var targetBuilding = Targets[rng.Next(0, Targets.Count)];

            var top = targetBuilding.transform.Find("TopLocation").transform.position;
            var bottom = targetBuilding.transform.Find("BottomLocation").transform.position;

            var xTarget = rng.Next((int)bottom.x, (int)top.x);
            var yTarget = rng.Next((int)bottom.y, (int)top.y);

            var rb = fb.GetComponent<Rigidbody2D>();
            var direction = new Vector2(xTarget - transform.position.x, yTarget - transform.position.y);
            rb.AddForce(direction * MeteorForce, ForceMode2D.Impulse);
            MaxTime = 0;
        }
    }
}
