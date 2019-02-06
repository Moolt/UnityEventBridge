using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventBridge
{
    public static class ObjectExtensions
    {
        public static IComponentEventHandler RequestEventHandlers(this GameObject target)
        {
            var handler = target.GetComponent<ComponentEventHandler>();

            if (handler == null)
            {
                handler = target.AddComponent<ComponentEventHandler>();
            }

            return handler;
        }

        public static IComponentEventHandler RequestEventHandlers(this Component target) => RequestEventHandlers(target.gameObject);
    }
}