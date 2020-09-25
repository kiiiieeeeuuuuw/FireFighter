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

    private Dictionary<float, GameObject> SpawnedTrails;

    private void Start()
    {
        SpawnedTrails = new Dictionary<float, GameObject>();
    }

    public void StartDrawing(Vector2 start, Vector2 target, float index)
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
        SpawnedTrails.Add(index, t);
    }

    public void DestroyTrajectory(string name)
    {
        string strMeteor = "Meteor_";
        float index = float.Parse(name.Substring(strMeteor.Length));

        Destroy(SpawnedTrails[index]);
        SpawnedTrails.Remove(index);
    }

    private void OnDrawGizmos()
    {
        if(DrawGizmos)
            Gizmos.DrawLine(StartingPoint, TargetPoint);        
    }
}
