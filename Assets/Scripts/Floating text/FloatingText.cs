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
    public Vector3 _motion;
    private float _duration;
    private float _lastShown;

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

    public float Duration
    {
        get => _duration;

        set => _duration = value;
    }

    public Vector3 Motion
    {
        get => _motion;

        set => _motion = value;
    }
    /// <summary>
    /// Method that shows floating text.
    /// </summary>
    public void Show()
    {
        _active = true;
        _lastShown = Time.time;
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

        if (Time.time - _lastShown > _duration)
            Hide();

        go.transform.position += _motion * Time.deltaTime;
    }
}
