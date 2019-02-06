# Unity Event Bridge
Sometimes you want to react to events happening in another object, e.g. subscribing to an objects `OnCollision` event.
This plug-in allows you to do exactly that with little effort.

![](https://raw.githubusercontent.com/Moolt/UnityEventBridge/master/Screenshots/events.png)

## Setup
If you want to get a quick overview you should check out the [demo project](https://github.com/Moolt/UnityRuntimePresets/archive/master.zip). 
You can also download the [package](https://github.com/Moolt/UnityEventBridge/raw/master/EventBridgePackage.unitypackage) containing only the essential scripts.

## Subscribing to events

The following example shows how to subscribe to the collision events of a cube with a rigidbody.
When it touches or bounces off the ground, a Debug-Message should be printed. The code could look like this:

```csharp
//Dont forget to include the namespace
using EventBridge;

public class GameController : MonoBehaviour
{
    //Any object you want to overve
    //This can be a Component or a GameObject reference
    [SerializeField] private Transform _objectToObserve;
    //The portal to all the events of the referenced object
    private IComponentEventHandler _eventHandler;

    private void Start()
    {
        //First an event handler has to be requested
        //It will contain all relevant events you may want to subscribe to
        _eventHandler = _objectToObserve.RequestEventHandlers();
        //In this example we subscribe to the CollisionEnter and CollisionExit events
        //The functions are added using the += operator and are called, when the event occurs
        _eventHandler.CollisionEnter += OnObjectTouchedGround;
        _eventHandler.CollisionExit += OnObjectBouncedOffGround;
    }

    private void OnDestroy()
    {
        //You should always unsubscribe from the events when the object is destroyed
        _eventHandler.CollisionEnter -= OnObjectTouchedGround;
        _eventHandler.CollisionExit -= OnObjectBouncedOffGround;
    }

    private void OnObjectTouchedGround(Collision collider)
    {
        Debug.Log("The cube touched the ground.");
    }

    private void OnObjectBouncedOffGround(Collision collider)
    {
        Debug.Log("The cube bounced off the ground.");
    }
}
```

Executing the code will result in something like this:

![](https://raw.githubusercontent.com/Moolt/UnityEventBridge/master/Screenshots/screenshot.png)

## How does it work?

Calling ``.RequestEventHandlers();`` on an object will create a new component on this object. This component listens to all available events unity may fire. If an event occurs, the respective `EventHandler`s will fire. The code is pretty straightforward, [you might want to take a look](https://github.com/Moolt/UnityEventBridge/blob/master/Assets/Scripts/EventBridge/ComponentEventHandler.cs).