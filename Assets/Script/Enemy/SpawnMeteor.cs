using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject Meteor;
    public GenerateBuilding Gb;
    public List<GameObject> Targets;

    public float MaxTime;
    private float PassedTime;

    public float MeteorForce;
    private float index;

    private Vector2 SpawnLeftLimit;
    private Vector2 SpawnRightLimit;

    public bool AimForPlayer;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Targets = Gb.GetBuildings();
        SpawnLeftLimit = new Vector2(Gb.GetLeftLimit().x, transform.position.y);
        SpawnRightLimit = new Vector2(Gb.GetRightLimit().x, transform.position.y);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PassedTime += Time.deltaTime;
        if(PassedTime > MaxTime && Targets.Count > 0)
        {
            // Instantiate rng
            var rng = new System.Random();

            // Instantiate meteor gameobject
            var xSpawn = rng.Next((int)SpawnLeftLimit.x, (int)SpawnRightLimit.x);
            var spawnLocation = new Vector3(xSpawn, transform.position.y);
            var fb = Instantiate(Meteor, spawnLocation, Quaternion.identity);
            fb.name = "Meteor_" + index;
            index++;

            float xTarget;
            float yTarget;
            // Determine target location
            if (AimForPlayer)
            {
                xTarget = Player.transform.position.x;
                yTarget = Player.transform.position.y;
            }
            else
            {
                var targetBuilding = Targets[rng.Next(0, Targets.Count)];
                var top = targetBuilding.transform.Find("TopLocation").transform.position;
                var bottom = targetBuilding.transform.Find("BottomLocation").transform.position;
                xTarget = rng.Next((int)bottom.x, (int)top.x);
                yTarget = rng.Next((int)bottom.y, (int)top.y);
            }

            // Shoot meteor towards target
            var rb = fb.GetComponent<Rigidbody2D>();
            var direction = new Vector2(xTarget - spawnLocation.x, yTarget - spawnLocation.y);
            rb.AddForce(direction * MeteorForce, ForceMode2D.Impulse);
            PassedTime = 0;
        }
    }
}
