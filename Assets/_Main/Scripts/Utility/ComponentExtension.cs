using UnityEngine;

namespace OttomanDisc.Utility
{
    public static class ComponentExtension
    {
        public static T GetComponentInChildrenAndParent<T>(this Component component) 
        {
            var comp = component.GetComponentInChildren<T>();

            if (comp != null) return comp;
            else comp = component.GetComponentInParent<T>();

            if (comp != null) return comp;
            else return (T)default;
        }
    }
}
