using UnityEngine;

namespace Assets.Script.Items
{    
    public class PickupRepair : MonoBehaviour, PickupItem
    {
        private GameObject BuildingManager;

        private void Start()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(BuildingManager == null)
                BuildingManager = GameObject.Find("BuildingGenerator");
            if (collision.collider.CompareTag("Player"))
            {
                PickupAction(collision.gameObject);
            }
        }

        public void PickupAction(GameObject collision)
        {
            // Determine closest building
            var buildingGen = BuildingManager.GetComponent<GenerateBuilding>();
            var buildings = buildingGen.GetBuildings();
            float minDistance = Mathf.Infinity;
            int closest = 0;
            for (int i = 0; i < buildings.Count; i++)
            {
                var building = buildings[i];
                var distance = Mathf.Abs(building.transform.position.x - collision.transform.position.x);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = i;
                }
            }

            //closest.GetComponentInChildren<BuildingHealth>().Repair();
            buildingGen.ReplaceBuilding(closest);

            // Destroy the icon
            Destroy(gameObject);
        }
    }
}
