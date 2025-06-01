
using UnityEngine;
using System; 
using UnityEngine.EventSystems;

namespace RW.MonumentValley
{
    // allows player to click on a block to set path goal
    [RequireComponent(typeof(Collider))]
    public class Clickable : MonoBehaviour,IPointerDownHandler
    { 
        // Nodes under this Transform
        private Node[] childNodes;
        public Node[] ChildNodes => childNodes;

        // invoked when collider is clicked
        public Action<Clickable,Vector3> clickAction;

        private void Awake()
        {
            childNodes = GetComponentsInChildren<Node>();
        }

        // alternative to OnMouseDown
        public void OnPointerDown(PointerEventData eventData)
        {
            if (clickAction != null)
            {
                // invoke the clickAction with world space raycast hit position
                clickAction.Invoke(this, eventData.pointerPressRaycast.worldPosition);
            }
        }
    }
}