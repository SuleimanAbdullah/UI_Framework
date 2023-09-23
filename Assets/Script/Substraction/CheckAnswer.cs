using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CheckAnswer : MonoBehaviour,IDropHandler
{
    private Image _thisImage;
    [SerializeField] private int _AnswerValue;
    [SerializeField] private Text _outPutText;
    private SubractionButtonManager _buttonManager;
    private Draggable[] _draggables;
    void Start()
    {
        _thisImage = GetComponent<Image>();
        _draggables = GameObject.FindObjectsOfType<Draggable>();
        _buttonManager = GameObject.Find("ButtonManager").GetComponent<SubractionButtonManager>();
        _outPutText.text = "Solve this! ";
    }
    public void OnDrop(PointerEventData eventData)
    {
        _AnswerValue = _buttonManager.CalculateAnswer();

        foreach (var button in _draggables)
        {
            if (_AnswerValue.ToString() == button.ReturnTextValue().text)
            {
                Draggable draggableButton = eventData.pointerDrag.GetComponent<Draggable>();
                draggableButton._oldPosition = _thisImage.rectTransform.localPosition;
                _outPutText.text = "Correct Answer";
                return;
            }
            else
            {
                _outPutText.text = "Wrong Answer";
            }
        }
    }
}
