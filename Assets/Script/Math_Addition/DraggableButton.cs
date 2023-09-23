using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    public Vector3 _oldPosition;
    private Image _buttonImage;
    public int _value;
    private Text _textValue;
    private ButtonManager _buttonManager;
   
    void Start()
    {
        _buttonImage = GetComponent<Image>();
        _oldPosition = _buttonImage.rectTransform.localPosition;
        _textValue = GetComponentInChildren<Text>();
        _buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        for (int i = 0; i < 2; i++)
        {
            int RandomNumber = Random.Range(_buttonManager.CalculateAnswer(), 15);
            _value = RandomNumber;
            _textValue.text = _value.ToString();
        }
       
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void ResetPosition()
    {
        _buttonImage.rectTransform.localPosition = _oldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _buttonImage.raycastTarget = true;
        ResetPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _buttonImage.raycastTarget = false;
    }

    public void GenarateRandomAnswer()
    {
        for (int i = 0; i < 2; i++)
        {
            int RandomNumber = Random.Range(_buttonManager.CalculateAnswer(), 15);
            _value = RandomNumber;
            _textValue.text = _value.ToString();
        }
    }

    public Text ReturnTextValue()
    {
        return _textValue;
    }
}
