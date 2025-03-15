using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform originalParent; //slot that the item is coming from
    CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       originalParent = transform.parent; //save original parent
        transform.SetParent(transform.root); //above other canvas'
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; //semi transparent when dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position; //follow mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; //enables the raycast
        canvasGroup.alpha = 1f; //not transparent

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //slot where item is dropped
        Slot ogSlot = originalParent.GetComponent<Slot>();

        if (dropSlot != null) 
        {
            if (dropSlot.currentItem != null)//is slot under a drag point
            {
                //slot has an item - swap items NOT WORKING
                dropSlot.currentItem.transform.SetParent(ogSlot.transform);
                ogSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                ogSlot.currentItem = null;
            }

            //move item into drop slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            //no slot
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //center
    }

  

    
}
