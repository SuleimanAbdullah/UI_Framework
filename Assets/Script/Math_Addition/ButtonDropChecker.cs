using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDropChecker : MonoBehaviour, IDropHandler
{
    private Image _thisImage;
    [SerializeField]private int _answerValue;
    [SerializeField] private Text _outPutText;
    private ButtonManager _buttonManager;
    private DraggableButton[] _dragableButtons;
    void Start()
    {
        _thisImage = GetComponent<Image>();
        _dragableButtons = GameObject.FindObjectsOfType<DraggableButton>();

         _buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        _outPutText.text = "Solve this! ";
        _answerValue = _buttonManager.CalculateAnswer();
    }
    public void OnDrop(PointerEventData eventData)
    {
        foreach (var button in _dragableButtons)
        {
            if (_answerValue.ToString() == button.ReturnTextValue().text)
            {
                DraggableButton draggableButton = eventData.pointerDrag.GetComponent<DraggableButton>();
                draggableButton._oldPosition = _thisImage.rectTransform.localPosition;
                _outPutText.text = "Correct Answer";
                return;//I put this to avoid this to change out put text ,cause this called more than once,next time it called the 
                       //Wrong Answer ,so to avoid this logic to go to else i use return.
            }
            else
            {
                _outPutText.text = "Wrong Answer";
            }
        }
    }
}
