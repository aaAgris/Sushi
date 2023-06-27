using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance { get; private set; }

    public Text priceField;
    public float totalPrice { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        UpdatePrice();
    }

    public void AddPrice(float price)
    {
        totalPrice += price;
        UpdatePrice();
    }

    public void UpdatePrice()
    {
        totalPrice = Mathf.Max(totalPrice, 0f);

        int discountPercentage = GetDiscountPercentage();

        float discountedPrice = totalPrice - (totalPrice * (discountPercentage / 100f));
        priceField.text = "Cena: " + discountedPrice.ToString("0.00") + " EUR";
    }

    private int GetDiscountPercentage()
    {
        int value = FindObjectOfType<incri1>().GetValue();
        int discountPercentage = 0;

        if (value >= 10 && value < 20)
        {
            discountPercentage = 10;
        }
        else if (value >= 20 && value < 30)
        {
            discountPercentage = 15;
        }
        else if (value >= 30 && value < 40)
        {
            discountPercentage = 20;
        }
        else if (value >= 40 && value < 50)
        {
            discountPercentage = 30;
        }
        else if (value >= 50 && value < 60)
        {
            discountPercentage = 45;
        }
        else if (value >= 60 && value < 70)
        {
            discountPercentage = 50;
        }
        else if (value >= 70 && value < 80)
        {
            discountPercentage = 60;
        }
        else if (value >= 80)
        {
            discountPercentage = 70;
        }

        return discountPercentage;
    }
}
