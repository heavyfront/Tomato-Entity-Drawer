using npg.tomatoecs;
using npg.tomatoecs.Entities;

namespace TomatoEntityDrawer
{
    public class BaseContext : Context
    {
        #region Editor Methods

        public TComponent GetComponent<TComponent>(Entity entity) where TComponent : struct, ITomatoComponent
        {
            return entity.GetComponent<TComponent>();
        }

        public void SetComponent<TComponent>(Entity entity, TComponent component)
            where TComponent : struct, ITomatoComponent
        {
            ref var comp = ref entity.GetComponent<TComponent>();
            comp = component;
        }

        public void AddComponent<TComponent>(Entity entity)
            where TComponent : struct, ITomatoComponent
        {
            entity.AddComponent<TComponent>();
        }

        #endregion
    }
}