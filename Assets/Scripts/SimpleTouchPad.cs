using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector2 origin;
    private Vector2 directon;

    void Awake()
    {
        directon = Vector2.zero;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        directon = directionRaw.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        directon = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        return directon;
    }
}
