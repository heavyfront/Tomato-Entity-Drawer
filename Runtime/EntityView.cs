using UnityEngine;

namespace TomatoEntityDrawer
{
    public class EntityView : MonoBehaviour
    {
        [SerializeField] protected uint _entityId;

        public uint EntityId => _entityId;

        public void SetupData(uint id)
        {
            _entityId = id;
        }
    }
}