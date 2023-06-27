using UnityEngine;
using UnityEngine.UI;

public class SliderObjects : MonoBehaviour
{
    public Slider slider;
    public Text textField;
    public int sliderValue;

    public GameObject rice;
    public GameObject sauce;
    public GameObject wrap;
    public GameObject ginger;
    public GameObject wasabi;

    public GameObject shrimp;
    public GameObject crab;
    public GameObject salmon;
    public GameObject chicken;

    public GameObject carrot;
    public GameObject onion;
    public GameObject avocado;
    public GameObject cucumber;

    public GameObject plate;
    public PlateController plateController;

    private void Start()
    {
        // Initialize slider value to 1
        slider.value = 1f;
        sliderValue = Mathf.RoundToInt(slider.value);
        UpdateObjects();
        UpdateTextField();
    }

    public void OnSliderValueChanged()
    {
        sliderValue = Mathf.RoundToInt(slider.value);
        UpdateObjects();
        UpdateTextField();
    }

    public void UpdateObjects()
    {
        switch (sliderValue)
        {
            case 1:
                ShowObjects(rice, sauce, wrap, ginger, wasabi);
                HideObjects(shrimp, crab, salmon, chicken, carrot, onion, avocado, cucumber);
                break;
            case 2:
                ShowObjects(shrimp, crab, salmon, chicken);
                HideObjects(rice, sauce, wrap, ginger, wasabi, carrot, onion, avocado, cucumber);
                break;
            case 3:
                ShowObjects(carrot, onion, avocado, cucumber);
                HideObjects(rice, sauce, wrap, ginger, wasabi, shrimp, crab, salmon, chicken);
                break;
        }
    }

    private void HideObjects(params GameObject[] objectsToHide)
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (IsIngredientInHiddenCategory(obj) && obj.transform.parent != plate.transform)
            {
                obj.SetActive(false);
            }
        }
    }

    private bool IsIngredientInHiddenCategory(GameObject ingredient)
    {
        // Modify this method based on your ingredient categorization logic
        switch (ingredient.name)
        {
            case "rice":
            case "sauce":
            case "wrap":
            case "ginger":
            case "wasabi":
                return sliderValue != 1;
            case "shrimp":
            case "crab":
            case "salmon":
            case "chicken":
                return sliderValue != 2;
            case "carrot":
            case "onion":
            case "avocado":
            case "cucumber":
                return sliderValue != 3;
            default:
                return false;
        }
    }

    private void ShowObjects(params GameObject[] objectsToShow)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }

    private void UpdateTextField()
    {
        switch (sliderValue)
        {
            case 1:
                textField.text = "Pamats";
                break;
            case 2:
                textField.text = "Gaļa";
                break;
            case 3:
                textField.text = "Dārzeņi";
                break;
        }
    }
}