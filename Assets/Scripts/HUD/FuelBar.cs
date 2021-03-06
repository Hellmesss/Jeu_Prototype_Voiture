using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxFuel(int fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
