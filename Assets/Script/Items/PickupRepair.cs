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
                var buildingGen = BuildingManager.GetComponent<GenerateBuilding>();
                var buildings = buildingGen.GetBuildings();
                float minDistance = Mathf.Infinity;
                int closest = 0;
                for(int i = 0; i < buildings.Count; i++)
                {
                    var building = buildings[i];
                    var distance = Mathf.Abs(building.transform.position.x - gameObject.transform.position.x);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closest = i;
                    }
                }

                //closest.GetComponentInChildren<BuildingHealth>().Repair();
                buildingGen.ReplaceBuilding(closest);
                Destroy(gameObject);
            }
        }
    }
}
