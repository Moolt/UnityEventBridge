using System;
using UnityEngine;

namespace EventBridge
{
    public interface IComponentEventHandler
    {
        event Action<Collider> TriggerEnter;

        event Action<Collider> TriggerStay;

        event Action<Collider> TriggerExit;

        event Action<Collision> CollisionEnter;

        event Action<Collision> CollisionStay;

        event Action<Collision> CollisionExit;

        event Action<Collision2D> CollisionEnter2D;

        event Action<Collision2D> CollisionStay2D;

        event Action<Collision2D> CollisionExit2D;

        event Action<Collider2D> TriggerEnter2D;

        event Action<Collider2D> TriggerStay2D;

        event Action<Collider2D> TriggerExit2D;

        event Action OnReset;

        event Action WhenDestroy;

        event Action Enable;

        event Action Disable;

        Component Component { get; }

        GameObject Target { get; }
    }
}
