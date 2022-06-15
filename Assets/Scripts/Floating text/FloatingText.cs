using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that is responsible for floating text.
/// </summary>
public class FloatingText : MonoBehaviour
{
    private bool _active;

    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public bool Active 
    { 
        get => _active;
        private set
        {
            if (_active == value)
                return;
            _active = value;
        }
    }
    /// <summary>
    /// Method that shows floating text.
    /// </summary>
    public void Show()
    {
        _active = true;
        lastShown = Time.time;
        go.SetActive(_active);
    }

    /// <summary>
    /// Method that hides floating text.
    /// </summary>
    public void Hide()
    {
        _active = false;
        go.SetActive(_active);
    }

    /// <summary>
    /// Method that updates floating text.
    /// </summary>
    public void UpdateFloatingText()
    {
        if (!_active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}
