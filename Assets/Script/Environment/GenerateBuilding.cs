using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour
{
    public GameObject Building;
    public float NumberOfBuidings;
    public float PlayerOffset;
    public float MaxBuildingOffsetX;
    public float MinBuildingOffsetX;

    public float MaxBuildingOffsetY;
    public float MinBuildingOffsetY;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        var playerPos = Player.GetComponent<Transform>().position;
        var b = Instantiate(Building,
            new Vector3(playerPos.x, playerPos.y - PlayerOffset, playerPos.z),
            Quaternion.identity);
        playerPos = b.transform.position;
        Instantiate(Building,
            new Vector3(playerPos.x - MaxBuildingOffsetX, playerPos.y - MaxBuildingOffsetY, playerPos.z),
            Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
