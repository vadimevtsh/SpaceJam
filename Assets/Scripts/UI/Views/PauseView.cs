using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Pause view class.
/// Passes button events.
/// </summary>
public class PauseView : BaseView
{
    // Events to attach to.
    public UnityAction OnResumeClicked;
    public UnityAction OnMenuClicked;

    /// <summary>
    /// Method called by Resume Button.
    /// </summary>
    public void ResumeClick()
    {
        OnResumeClicked?.Invoke();
    }

    /// <summary>
    /// Method called by Menu Button.
    /// </summary>
    public void SettingsClick()
    {
        OnMenuClicked?.Invoke();
    }
}