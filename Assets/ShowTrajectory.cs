using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrajectory : MonoBehaviour
{
    public Vector2 StartingPoint;
    public Vector2 TargetPoint;

    public bool draw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDrawing(Vector2 start, Vector2 target)
    {
        StartingPoint = start;
        TargetPoint = target;
        draw = true;
    }

    private void OnDrawGizmos()
    {
        if(draw)
            Gizmos.DrawLine(StartingPoint, TargetPoint);        
    }
}
