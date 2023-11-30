using System;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private Text _field1;
    [SerializeField] private Text _field2;
    [SerializeField] private Text _resultText;

    private int _result;

    public void Sum()
    {
        Execute((n, m) => n + m);
    }

    public void Substract()
    {
        Execute((n, m) => n - m);
    }

    public void Multiply()
    {
        Execute((n, m) => n * m);
    }

    public void Divide()
    {
        if (ConvertToInt(out int number1, out int number2))
        {
            if (number2 == 0)
                _resultText.text = "Error! Divide by zero";
            else
            {
                _result = number1 / number2;
                PrintResult(_result);
            }
        }
    }

    private void Execute(Func<int, int, int> operation)
    {
        if (ConvertToInt(out int number1, out int number2))
        {
            int result = operation(number1, number2);
            PrintResult(result);
        }
        else
            PrintError();
    }

    private bool ConvertToInt(out int result1, out int result2)
    {
        return int.TryParse(_field1.text, out result1) & int.TryParse(_field2.text, out result2);
    }

    private void PrintResult(int result)
    {
        _resultText.text = result.ToString();
    }

    private void PrintError()
    {
        _resultText.text = "Incorrect input numbers";
        _field1.text = string.Empty;
        _field2.text = string.Empty;
    }
}