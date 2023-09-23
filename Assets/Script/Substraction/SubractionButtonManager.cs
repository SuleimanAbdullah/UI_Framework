using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubractionButtonManager : MonoBehaviour
{

    [SerializeField] private Text _textNumber1;
    [SerializeField] private Text _textNumber2;
    private int _number1;
    private int _number2;
    private int _answer;

    [SerializeField] private GameObject[] _draggables;
    void Start()
    {
        _number1 = Random.Range(2, 30);
        _number2 = Random.Range(2, 30);
        _textNumber1.text = _number1.ToString();
        _textNumber2.text = _number2.ToString();
        foreach (var button in _draggables)
        {
            button.SetActive(true);
        }
        CalculateAnswer();
    }

    public int CalculateAnswer()
    {
        _answer = _number1 - _number2;
        return _answer;
    }

    public void GenerateNextEquation()
    {
        _number1 = Random.Range(2, 30);
        _number2 = Random.Range(2, 30);
        _textNumber1.text = _number1.ToString();
        _textNumber2.text = _number2.ToString();
        CalculateAnswer();
    }
}
