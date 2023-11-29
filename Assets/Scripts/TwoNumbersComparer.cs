using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private Text _field1;
    [SerializeField] private Text _field2;
    [SerializeField] private Text _resultText;

    private int _number1;
    private int _number2;

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

    private void SetResult(int number)
    {
        _resultText.text = number.ToString();
    }

    public void Compare()
    {
        if (ConvertToInt())
        {
            if (_number1 == _number2)
                _resultText.text = "Numbers are equal";
            else if (_number1 > _number2)
                SetResult(_number1);
            else
                SetResult(_number2);
        }
    }
}
