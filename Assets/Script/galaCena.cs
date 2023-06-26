using UnityEngine;
using UnityEngine.UI;

public class galaCena : MonoBehaviour
{
    public PriceManager priceManager;
    public Text priceText;

    private void Start()
    {
        // Make sure the PriceManager is assigned
        if (priceManager == null)
        {
            Debug.LogError("PriceManager is not assigned to PriceDisplay!");
            return;
        }

        // Make sure the Text component is assigned
        if (priceText == null)
        {
            Debug.LogError("Text component is not assigned to PriceDisplay!");
            return;
        }

        // Display the initial price
        UpdatePriceField();

        // Subscribe to the price update event
        priceManager.OnPriceUpdate += UpdatePriceField;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the price update event to prevent memory leaks
        priceManager.OnPriceUpdate -= UpdatePriceField;
    }

    private void UpdatePriceField()
    {
        float totalPrice = priceManager.TotalPrice;
        priceText.text = "Total Price: " + totalPrice.ToString("0.00") + " EUR";
    }

}
