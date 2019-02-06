using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventBridge;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _objectToObserve;
    private IComponentEventHandler _eventHandler;

    private void Start()
    {
        _eventHandler = _objectToObserve.RequestEventHandlers();
        _eventHandler.CollisionEnter += OnObjectTouchedGround;
        _eventHandler.CollisionExit += OnObjectBouncedOffGround;
    }

    private void OnDestroy()
    {
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
