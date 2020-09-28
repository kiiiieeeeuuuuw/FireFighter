using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckForPlayerPresence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var hits = Physics2D.RaycastAll(transform.position, Vector2.up).Where(x => x.collider.CompareTag("Player"));
        RaycastHit2D hit = new RaycastHit2D();
        if (hits.Count() > 0)
            hit = hits.First();
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            GetComponentInParent<ManageActiveFires>().ChangeMiddleFire(name);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, 999));
    }
}
