using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fruit : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Image _image;
    public Vector3 _oldPosition;
    void Start()
    {
        _image = GetComponent<Image>();
        _oldPosition = _image.rectTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void ResetPosition()
    {
        _image.rectTransform.localPosition = _oldPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        ResetPosition();
    }
}
