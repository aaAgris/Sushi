using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour
{
    public Text priceField;
    private float totalPrice = 0f;

    private void Start()
    {
        UpdatePrice();
    }

    public void AddPrice(float price)
    {
        totalPrice += price;
        UpdatePrice();
    }

    private void UpdatePrice()
    {
        totalPrice = Mathf.Max(totalPrice, 0f); // Ensure the price doesn't go below zero
        priceField.text = "Price: " + totalPrice.ToString("0.00") + " EUR";
    }
}
