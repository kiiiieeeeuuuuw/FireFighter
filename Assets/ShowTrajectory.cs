using System.Net;
using UnityEngine;

public class ShowTrajectory : MonoBehaviour
{
    public Vector2 StartingPoint;
    public Vector2 TargetPoint;

    public GameObject Trail;

    public bool draw;
    public bool TrailShown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (draw && !TrailShown)
        {
            Vector2 direction = StartingPoint - TargetPoint;
            //Instantiate(Trail, StartingPoint, Quaternion.identity);
            var t = Instantiate(Trail, StartingPoint, Quaternion.LookRotation(direction));
            
            TrailShown = true;
        }
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
