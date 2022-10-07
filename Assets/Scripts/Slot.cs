using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = transform as RectTransform;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().newSlot = this;
        }
    }

}
