using System;
using UnityEngine;

namespace EventBridge
{
    public class ComponentEventHandler : MonoBehaviour, IComponentEventHandler
    {
        private void OnTriggerEnter(Collider other) => TriggerEnter?.Invoke(other);

        private void OnTriggerStay(Collider other) => TriggerStay?.Invoke(other);

        private void OnTriggerExit(Collider other) => TriggerExit?.Invoke(other);

        private void OnCollisionEnter(Collision other) => CollisionEnter?.Invoke(other);

        private void OnCollisionStay(Collision other) => CollisionStay?.Invoke(other);

        private void OnCollisionExit(Collision other) => CollisionExit?.Invoke(other);

        private void OnCollisionEnter2D(Collision2D other) => CollisionEnter2D?.Invoke(other);

        private void OnCollisionStay2D(Collision2D other) => CollisionStay2D?.Invoke(other);

        private void OnCollisionExit(Collision2D other) => CollisionExit2D?.Invoke(other);

        private void OnTriggerEnter2D(Collider2D other) => TriggerEnter2D?.Invoke(other);

        private void OnTriggerStay2D(Collider2D other) => TriggerStay2D?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other) => TriggerExit2D?.Invoke(other);

        private void Reset() => OnReset?.Invoke();

        private void OnDestroy() => WhenDestroy?.Invoke();

        private void OnEnable() => Enable?.Invoke();

        private void OnDisable() => Disable?.Invoke();

        public event Action<Collider> TriggerEnter;

        public event Action<Collider> TriggerStay;

        public event Action<Collider> TriggerExit;

        public event Action<Collision> CollisionEnter;

        public event Action<Collision> CollisionStay;

        public event Action<Collision> CollisionExit;

        public event Action<Collision2D> CollisionEnter2D;

        public event Action<Collision2D> CollisionStay2D;

        public event Action<Collision2D> CollisionExit2D;

        public event Action<Collider2D> TriggerEnter2D;

        public event Action<Collider2D> TriggerStay2D;

        public event Action<Collider2D> TriggerExit2D;

        public event Action OnReset;

        public event Action WhenDestroy;

        public event Action Enable;

        public event Action Disable;

        public Component Component => this;

        public GameObject Target => gameObject;
    }
}