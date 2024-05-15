using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Variable to keep track of object's raycast
    public Image image;

    //Initialize item variable
    [HideInInspector] public Item item;
    //Variable to keep track of parent object
    [HideInInspector] public Transform parentAfterDrag;

    //Initialize item slots 
    public void InitializeItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.image;
    }

    //Begin dragging item, assign original parent object to variable
    //Set canvas as parent of the object once "dragging" begin to get object on top layer
    //Once dragging begin, disable raycast of object so cursor can find new slot
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    
    //To Move item along with cursor's position (Dragging item)
    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
        
    }

    //Stop dragging item, assign variable as the parent of the object (Snap back to original slot)
    //Once dragging stop, re-enable raycast of object so it can be interacted with again
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

}
