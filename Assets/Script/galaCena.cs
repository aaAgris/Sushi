using UnityEngine;
using UnityEngine.UI;

public class galaCena : MonoBehaviour
{
    public Text totalPriceText;

    private void Start()
    {
        if (PriceManager.Instance != null)
        {
            float totalPrice = PriceManager.Instance.totalPrice;
            totalPriceText.text = "Gala cena: "+totalPrice.ToString("0.00") + " EUR";
        }
        else
        {
            Debug.LogError("PriceManager instance not found.");
        }
    }

    // Other MaksasLogs code...
}
