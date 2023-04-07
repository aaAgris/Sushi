using UnityEngine;
using UnityEngine.UI;

public class incri1 : MonoBehaviour
{

    public Text resultText;
    public Button subtractButton;
    public Button addButton;

    private int value = 0;

    void Start()
    {
        UpdateText();
    }

    public void Add()
    {
        value = int.Parse(resultText.text) + 1;
        UpdateText();
    }

    public void Subtract()
    {
        value = int.Parse(resultText.text) - 1;
        UpdateText();
    }

    private void UpdateText()
    {
        value = Mathf.Clamp(value, 0, 110);
        resultText.text = value.ToString();
        subtractButton.interactable = (value > 0);
        addButton.interactable = (value < 110);
    }
}

