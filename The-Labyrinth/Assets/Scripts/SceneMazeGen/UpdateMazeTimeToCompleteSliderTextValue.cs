using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateMazeTimeToCompleteSliderTextValue : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void UpdateValue()
    {
        if(slider.value < 3600)
        {
            text.text = slider.value.ToString();
        }
        else
        {
            text.text = "Infinite";
        }

    }
}
