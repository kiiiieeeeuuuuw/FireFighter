using UnityEngine;

namespace Assets.Script.Items
{
    public interface PickupItem
    {
        void PickupAction(GameObject collision);
    }
}
