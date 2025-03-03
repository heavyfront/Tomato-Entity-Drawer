# Tomato Entity Drawer

Visual debug for Tomato ECS. Allows you to see and modify components and values in runtime

## How to Install

Simply download the library into your Unity project and access the utilities across your scripts or import it in Unity
with
the Unity Package Manager using this URL:

`https://github.com/heavyfront/Tomato-Entity-Drawer.git`

## How to use

To view and edit any entities (without view), you need to create an object on the scene and initialize it.
For example, in the place where you have the initialization of the ECS

```csharp

 public void Initialize()
        {
            // your initialization
            var go = new GameObject("WorldContextObject");
            Object.DontDestroyOnLoad(go);
            _tomatoContextObject = go.AddComponent<TomatoContextObject>();
            _tomatoContextObject.Initialize(_context);

        }

```

To view and edit entities with view, that are present on the scene, you can create a base class for the visual (in my case, it is
EntityView), create the EntityId property inside and set it when creating object. Now you just need to inherit all other
views from this class. In this case, the Entity mode flag will appear in the inspector on such an object. When it is
enabled, the entity components for this object will be displayed.

```csharp

  public abstract class EntityView : MonoBehaviour
    {
        [SerializeField, ReadOnly] protected uint _entityId;

        public uint EntityId => _entityId;

        public void SetupData(uint id)
        {
            _isEntityCreated = true;
            _entityId = id;
        }


```