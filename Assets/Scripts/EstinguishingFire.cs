using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstinguishingFire : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void estinguishingFire()
    {
        slider.value--;
    }
}
