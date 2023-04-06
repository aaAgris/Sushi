using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SliderValueToText : MonoBehaviour {
  [SerializeField] public Slider sliderUI;
  [SerializeField] public TextMeshProUGUI textSliderValue;

  void Start (){
    textSliderValue = GetComponent<TextMeshProUGUI>();
    ShowSliderValue();
  }

  public void ShowSliderValue () {
    string sliderMessage = "Slider value = " + sliderUI.value;
    textSliderValue.text = sliderMessage;
  }
}