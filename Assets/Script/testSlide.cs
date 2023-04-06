using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class testSlide : MonoBehaviour
{

public Slider slider;
public TextMeshProUGUI sliderText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = slider.value.ToString();
    }
}
