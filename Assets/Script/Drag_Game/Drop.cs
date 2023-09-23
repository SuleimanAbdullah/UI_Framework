using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour,IDropHandler
{
    private Image _dropImage;

    [SerializeField]private string _fruitName;

    void Start()
    {
        _dropImage = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_fruitName == eventData.pointerDrag.name)
        {
            Fruit fruit = eventData.pointerDrag.GetComponent<Fruit>();
            fruit._oldPosition = _dropImage.rectTransform.localPosition;
        }
    }
}
