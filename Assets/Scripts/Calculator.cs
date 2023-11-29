using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private Text _field1;
    [SerializeField] private Text _field2;
    [SerializeField] private Text _resultText;

    private int _number1;
    private int _number2;
    private int _result;

    private bool ConvertToInt()
    {
        if (int.TryParse(_field1.text, out int result1) && int.TryParse(_field2.text, out int result2))
        {
            _number1 = result1;
            _number2 = result2;
            return true;
        }
        else
        {
            _resultText.text = "Incorrect input numbers";
            _field1.text = string.Empty;
            _field2.text = string.Empty;
            return false;
        }
    }

    private void SetResult()
    {
        _resultText.text = _result.ToString();
    }

    public void Sum()
    {
        if (ConvertToInt())
        {
            _result = _number1 + _number2;
            SetResult();
        }
    }

    public void Substract()
    {
        if (ConvertToInt())
        {
            _result = _number1 - _number2;
            SetResult();
        }
    }

    public void Multiply()
    {
        if (ConvertToInt())
        {
            _result = _number1 * _number2;
            SetResult();
        }
    }

    public void Divide()
    {
        if (ConvertToInt())
        {
            if (_number2 == 0)
                _resultText.text = "Error! Divide by zero";
            else
            {
                _result = _number1 / _number2;
                SetResult();
            }
        }
    }
}