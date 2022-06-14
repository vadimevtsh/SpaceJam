using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that represents extinguishing fire.
/// </summary>
public class ExtinguishingFire : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    /// <summary>
    /// Method that is responsible for decreasing slider value while extinguishing fire.
    /// </summary>
    public void ExtinguishingOccurredFire()
    {
        slider.value--;
    }
}
