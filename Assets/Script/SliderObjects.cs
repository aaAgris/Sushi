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

    private void UpdateObjects()
    {
        switch (sliderValue)
        {
            case 1:
                HideObjects(shrimp, carrot, crab, onion, salmon, chicken, avocado, cucumber);
                ShowObjects(rice, sauce, wrap, ginger, wasabi);
                break;
            case 2:
                HideObjects(rice, sauce, wrap, ginger, wasabi, carrot, onion, avocado, cucumber);
                ShowObjects(shrimp, crab, salmon, chicken);
                break;
            case 3:
                HideObjects(rice, sauce, wrap, ginger, wasabi, shrimp, crab, salmon, chicken);
                ShowObjects(carrot, onion, avocado, cucumber);
                break;
        }
    }

    private void HideObjects(params GameObject[] objectsToHide)
    {
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
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
