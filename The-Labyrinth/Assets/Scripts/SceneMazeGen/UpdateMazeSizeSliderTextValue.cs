using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateMazeSizeSliderTextValue : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void UpdateValue()
    {
        text.text = slider.value.ToString();
    }
}
