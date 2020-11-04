using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyGameObject : MonoBehaviour
{
    public float LifeTime;

    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
            Destroy(gameObject);
    }
}
