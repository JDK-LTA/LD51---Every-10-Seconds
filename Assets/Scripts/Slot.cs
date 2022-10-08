using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransform;
    [ReadOnly] public Card activeCard = null;
    [ReadOnly] public bool filled = false;
    
    private void Awake()
    {
        rectTransform = transform as RectTransform;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().newSlot = this;
            activeCard = eventData.pointerDrag.GetComponent<Card>();
            filled = true;
        }
    }

    public void Empty()
    {
        filled = false;
        activeCard = null;
    }
}
