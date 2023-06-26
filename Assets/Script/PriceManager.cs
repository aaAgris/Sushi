using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour
{
    public Text priceField;
    private float totalPrice = 0f;

    // Define the event to be triggered when the price is updated
    public event System.Action OnPriceUpdate;

    public float TotalPrice => totalPrice;

    private void Start()
    {
        UpdatePrice();
    }

    public void AddPrice(float price)
    {
        totalPrice += price;
        UpdatePrice();

        // Trigger the event to notify subscribers of the price update
        OnPriceUpdate?.Invoke();
    }

    private void UpdatePrice()
    {
        totalPrice = Mathf.Max(totalPrice, 0f); // Ensure the price doesn't go below zero
        priceField.text = "Price: " + totalPrice.ToString("0.00") + " EUR";
    }
}
