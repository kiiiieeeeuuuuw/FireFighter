using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRepeat : MonoBehaviour
{
    public float spriteSize;
    public float moved, startX, originalOffset;
    public GameObject camera;
    
    public float speedFactor;
    public DirectionEnum dir;
    // Start is called before the first frame update
    void Start()
    {
        var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        spriteSize = (bounds.max.x - bounds.min.x);
        startX = transform.position.x;
        originalOffset = camera.transform.position.x - startX;
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

        if (Mathf.Abs(transform.position.x - startX) > spriteSize * 2)
        {            
            startX = camera.transform.position.x;
            transform.position = new Vector3(startX + (moved < 0?originalOffset:-
                originalOffset), transform.position.y);
            moved = 0;
        }
        else
            transform.position = new Vector3(transform.position.x + moved, transform.position.y);
    }
}
