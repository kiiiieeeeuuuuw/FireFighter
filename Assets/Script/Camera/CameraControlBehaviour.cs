using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlBehaviour : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        Camera.main.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
