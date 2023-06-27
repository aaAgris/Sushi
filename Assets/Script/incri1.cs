/*using UnityEngine;
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
}*/
using UnityEngine;
using UnityEngine.UI;

public class incri1 : MonoBehaviour
{
    public Text resultText;
    public Button subtractButton;
    public Button addButton;
    private PriceManager priceManager; // Reference to the PriceManager script

    private int value = 1;

    void Start()
    {
        priceManager = FindObjectOfType<PriceManager>();
        UpdateText();
    }

    public void Add()
    {
        value = int.Parse(resultText.text) + 1;
        UpdateText();

        if (priceManager != null)
        {
            priceManager.AddPrice(1f); // Call AddPrice() in the PriceManager script
        }
    }

    public void Subtract()
    {
        value = int.Parse(resultText.text) - 1;
        UpdateText();

        if (priceManager != null)
        {
            priceManager.AddPrice(-1f); // Call AddPrice() in the PriceManager script
        }
    }

    public int GetValue()
    {
        return value;
    }

    private void UpdateText()
    {
        value = Mathf.Clamp(value, 1, 110);
        resultText.text = value.ToString();
        subtractButton.interactable = (value > 1);
        addButton.interactable = (value < 110);
    }
}



