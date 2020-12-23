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
            var leftOrRightMultiplier = LeftOrRight[rng.Next(0, 2)];
            var lowerOrHigherMultiplier = LowerOrHigher[rng.Next(0, 2)];
            var referenceBuilding = leftOrRightMultiplier == 1 ? RightBuilding : LeftBuilding;
            var referencePosition = referenceBuilding.transform.position;

            var deltaX = rng.Next((int)MinBuildingOffsetX, (int)MaxBuildingOffsetX) * leftOrRightMultiplier;
            var deltaY = rng.Next((int)MinBuildingOffsetY, (int)MaxBuildingOffsetY) * lowerOrHigherMultiplier;

            var building = Instantiate(Building, new Vector3(referencePosition.x + deltaX, referencePosition.y + deltaY, referencePosition.z), Quaternion.identity, this.transform);            

            if (leftOrRightMultiplier == -1) LeftBuilding = building;
            if (leftOrRightMultiplier == 1) RightBuilding = building;
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

    public void ReplaceBuilding(int index)
    {
        var pos = Buildings[index].transform.position;
        Buildings[index].GetComponentInChildren<PlayCloudsAndDestroy>().PlayClouds();
        Buildings[index] = Instantiate(Building, pos, Quaternion.identity, this.transform);
    }
}
