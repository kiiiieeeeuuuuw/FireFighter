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

    private float[] LeftOrRight = { -1, 1 };
    private float[] LowerOrHigher = { -1, 1 };

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        var playerPos = Player.GetComponent<Transform>().position;
        var startBuilding = Instantiate(Building,
            new Vector3(playerPos.x, playerPos.y - PlayerOffset, playerPos.z), Quaternion.identity, this.transform);

        List<GameObject> buildings = new List<GameObject> { startBuilding };
        var leftB = startBuilding;
        var rightB = startBuilding;
        System.Random rng = new System.Random();

        for (int i = 0; i < NumberOfBuidings - 1; i++)
        {            
            var lOrRMultiplier = LeftOrRight[rng.Next(0, 2)];
            var lOrHMultiplier = LowerOrHigher[rng.Next(0, 2)];
            var refBuilding = lOrRMultiplier == 1 ? rightB : leftB;
            var refPos = refBuilding.transform.position;

            var deltaX = rng.Next((int)MinBuildingOffsetX, (int)MaxBuildingOffsetX) * lOrRMultiplier;
            var deltaY = rng.Next((int)MinBuildingOffsetY, (int)MaxBuildingOffsetY) * lOrHMultiplier;

            var building = Instantiate(Building, new Vector3(refPos.x + deltaX, refPos.y + deltaY, refPos.z), Quaternion.identity, this.transform);            

            if (lOrRMultiplier == -1) leftB = building;
            if (lOrRMultiplier == 1) rightB = building;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
