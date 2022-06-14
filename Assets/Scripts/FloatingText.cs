using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that is responsible for floating text.
/// </summary>
public class FloatingText : MonoBehaviour
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    /// <summary>
    /// Method that shows floating text.
    /// </summary>
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    /// <summary>
    /// Method that hides floating text.
    /// </summary>
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    /// <summary>
    /// Method that updates floating text.
    /// </summary>
    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}
