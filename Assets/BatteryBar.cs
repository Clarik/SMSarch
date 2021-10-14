using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image BatteryBarLogo;
    public void SetMaxBattery(float time)
    {
        slider.maxValue = time;
        slider.value = time;

        BatteryBarLogo.color = gradient.Evaluate(1f);
    }

    public void SetBattery(float time)
    {
        slider.value = time;
        BatteryBarLogo.color = gradient.Evaluate(slider.normalizedValue);
    }
}
