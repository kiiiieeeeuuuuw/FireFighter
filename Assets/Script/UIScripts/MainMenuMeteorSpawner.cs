using UnityEngine;

public class MainMenuMeteorSpawner : MonoBehaviour
{
    [Header("MeteorParameters")]
    public GameObject Meteor;
    public float MaxTime;
    
    [Header("Positions")]
    public GameObject StartLeft;
    public GameObject StartRight;
    public GameObject EndLeft;
    public GameObject EndRight;

    private Vector3 StartLeftPos;
    private Vector3 StartRightPos;
    private Vector3 EndLeftPos;
    private Vector3 EndRightPos;

    private float PassedTime;

    // Start is called before the first frame update
    void Start()
    {
        StartLeftPos = StartLeft.transform.position;
        StartRightPos = StartRight.transform.position;
        EndLeftPos = EndLeft.transform.position;
        EndRightPos = EndRight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PassedTime > MaxTime)
        {            
            var spawnLocation = new Vector2(Random.Range(StartLeftPos.x, StartRightPos.x), StartLeftPos.y);
            var targetLocation = new Vector2(Random.Range(EndLeftPos.x, EndRightPos.x), EndLeftPos.y);

            var direction = new Vector2(targetLocation.x - spawnLocation.x, targetLocation.y - spawnLocation.y);

            var meteor = Instantiate(Meteor, spawnLocation, Quaternion.identity, transform);
            var force = Random.Range(0.3f, 0.8f);
            meteor.GetComponent<Rigidbody2D>().velocity = direction * force;
            PassedTime = 0;
        }
        else
            PassedTime += Time.deltaTime;
    }
}
