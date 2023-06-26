using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance { get; private set; }

    public Text priceField;
    public float totalPrice { get; private set; }

<<<<<<< Updated upstream
=======

    private void Awake()
    {
        // Ensure only one instance of PriceManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

>>>>>>> Stashed changes
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

