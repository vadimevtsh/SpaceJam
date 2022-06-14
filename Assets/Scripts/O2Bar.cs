using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that is responsible for oxygen bar.
/// </summary>
public class O2Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /// <summary>
    /// Method that sets oxygen bar to the maximum level.
    /// </summary>
    /// <param name="oxygen">Maximum level of oxygen</param>
    public void SetMaxOxygen(float oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;

        fill.color = gradient.Evaluate(1f);
    }

    /// <summary>
    /// Method that sets oxygen to the given value.
    /// </summary>
    /// <param name="oxygen">Desired value of oxygen to be set to</param>
    public void SetOxygen(float oxygen)
    {
        slider.value = oxygen;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
