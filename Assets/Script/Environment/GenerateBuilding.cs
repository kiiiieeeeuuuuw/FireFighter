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

    private List<GameObject> Buildings;
    private GameObject LeftBuilding;
    private GameObject RightBuilding;

    public GameObject Player;
    public GameObject EmberCounter;

    private void Awake()
    {
        var playerPos = Player.GetComponent<Transform>().position;
        var startBuilding = Instantiate(Building,
            new Vector3(playerPos.x, playerPos.y - PlayerOffset, playerPos.z), Quaternion.identity, this.transform);        

        Buildings = new List<GameObject> { startBuilding };
        LeftBuilding = startBuilding;
        RightBuilding = startBuilding;
        System.Random rng = new System.Random();

        for (int i = 0; i < NumberOfBuidings - 1; i++)
        {            
            var lOrRMultiplier = LeftOrRight[rng.Next(0, 2)];
            var lOrHMultiplier = LowerOrHigher[rng.Next(0, 2)];
            var refBuilding = lOrRMultiplier == 1 ? RightBuilding : LeftBuilding;
            var refPos = refBuilding.transform.position;

            var deltaX = rng.Next((int)MinBuildingOffsetX, (int)MaxBuildingOffsetX) * lOrRMultiplier;
            var deltaY = rng.Next((int)MinBuildingOffsetY, (int)MaxBuildingOffsetY) * lOrHMultiplier;

            var building = Instantiate(Building, new Vector3(refPos.x + deltaX, refPos.y + deltaY, refPos.z), Quaternion.identity, this.transform);            

            if (lOrRMultiplier == -1) LeftBuilding = building;
            if (lOrRMultiplier == 1) RightBuilding = building;
            Buildings.Add(building);
        }

    }

    public List<GameObject> GetBuildings()
    {
        return Buildings;
    }

    public Vector3 GetLeftLimit()
    {
        return LeftBuilding.transform.position;
    }

    public Vector3 GetRightLimit()
    {
        return RightBuilding.transform.position;
    }
}
