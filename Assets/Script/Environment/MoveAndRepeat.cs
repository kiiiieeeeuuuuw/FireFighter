using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRepeat : MonoBehaviour
{
    public float spriteSize;
    public float moved;
    public GameObject camera;
    
    public float speedFactor;
    public DirectionEnum dir;
    // Start is called before the first frame update
    void Start()
    {
        var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        spriteSize = (bounds.max.x - bounds.min.x);
    }

    // Update is called once per frame
    void Update()
    {
        switch (dir)
        {
            case DirectionEnum.None:
                break;
            case DirectionEnum.Left:
                moved -= Time.deltaTime * speedFactor;
                break;
            case DirectionEnum.Right:
                moved += Time.deltaTime * speedFactor;
                break;
        }

        if (moved > spriteSize)
        {
            moved = 0;
            transform.position = new Vector3(camera.transform.position.x, transform.position.y);
        }
        else
            transform.position = new Vector3(transform.position.x + moved, transform.position.y);
    }
}
