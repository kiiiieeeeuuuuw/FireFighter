using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpawnMeteorTrajectory : MonoBehaviour
{
    public Vector2 StartingPoint;
    public Vector2 TargetPoint;
    public float Angle;

    public GameObject Trail;

    public bool DrawGizmos;

    private Dictionary<string, GameObject> SpawnedTrails;

    private void Start()
    {
        SpawnedTrails = new Dictionary<string, GameObject>();
    }

    public void StartDrawing(Vector2 start, Vector2 target, int index)
    {
        StartingPoint = start;
        TargetPoint = target;
        DrawGizmos = true;

        var t = Instantiate(Trail, StartingPoint, Quaternion.identity);
        t.name = "MeteorTrail_" + index;
        var p1 = StartingPoint;
        var p2 = TargetPoint;
        Angle = (Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI);
        t.transform.RotateAround(StartingPoint, Vector3.forward, Angle);
    }

    public void DestroyTrajectory(string name)
    {

    }

    private void OnDrawGizmos()
    {
        if(DrawGizmos)
            Gizmos.DrawLine(StartingPoint, TargetPoint);        
    }
}
