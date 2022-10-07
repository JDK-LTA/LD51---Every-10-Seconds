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
    private Slot oldSlot;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        oldSlot = newSlot;
        StartCoroutine(MovingUpdate());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        isDragging = true;
        StartCoroutine(FollowMouse());

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        isDragging = false;
        StartCoroutine(MovingUpdate());
    }

    public void MoveToSlot()
    {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.position, newSlot.rectTransform.position, ref velocity, dampSpeed); 
    }
    public void MoveToNewSlot()
    {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.position, newSlot.rectTransform.position, ref velocity, dampSpeed * 0.2f);
            oldSlot = newSlot;
    }

    IEnumerator FollowMouse()
    {
        while (isDragging)
        {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.position, Input.mousePosition, ref velocity, dampSpeed);
            yield return new WaitForFixedUpdate();
        }
        yield break;

    }

    IEnumerator MovingUpdate()
    {
        if (oldSlot == newSlot)
        {
            while (Vector2.Distance(rectTransform.position, newSlot.rectTransform.position) > 1f)
            {
                MoveToSlot();
                yield return new WaitForFixedUpdate();
            }
            rectTransform.position = newSlot.rectTransform.position;
            yield break;
        }
        else
        {
            print("whee");
            while (Vector2.Distance(rectTransform.position, newSlot.rectTransform.position) > 1f)
            {
                MoveToNewSlot();
                yield return new WaitForFixedUpdate();
            }
            rectTransform.position = newSlot.rectTransform.position;
            yield break;
        }
        

    }
}
