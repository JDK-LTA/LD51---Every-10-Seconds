using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField]
    private float dampSpeed = 0.05f;

    private RectTransform rectTransform;
    private Vector3 velocity = Vector3.zero;
    private bool isDragging;
    public Slot newSlot;
    private Slot currentSlot;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        isDragging = false;
    }

    void FollowMouse()
    {
        rectTransform.position = Vector3.SmoothDamp(rectTransform.position, Input.mousePosition, ref velocity, dampSpeed);
    }

    public void MoveToSlot()
    {
        if(currentSlot != newSlot)
        {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.position, currentSlot.rectTransform.position, ref velocity, dampSpeed*0.01f);
            currentSlot = newSlot;
        }
        else
        {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.position, currentSlot.rectTransform.position, ref velocity, dampSpeed);
        }
        
        
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            FollowMouse();
        }
        else if (Vector2.Distance(rectTransform.position, newSlot.rectTransform.position) > 1f)
        {
            MoveToSlot();
        }
        else
        {
            rectTransform.position = currentSlot.rectTransform.position;
        }
        
    }
}
