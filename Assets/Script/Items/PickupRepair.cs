using UnityEngine;

namespace Assets.Script.Items
{    
    public class PickupRepair : MonoBehaviour
    {
        public GameObject BuildingManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                // Determine closest building
                var buildings = BuildingManager.GetComponent<GenerateBuilding>().GetBuildings();
                float minDistance = Mathf.Infinity;
                GameObject closest = null;
                foreach(var building in buildings)
                {
                    var distance = Mathf.Abs(building.transform.position.x - gameObject.transform.position.x);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closest = building;
                    }
                }

                closest.GetComponentInChildren<BuildingHealth>().Repair();
                Destroy(gameObject);
            }
        }
    }
}
