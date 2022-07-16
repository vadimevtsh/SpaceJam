using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Game view class.
/// Passes button events.
/// </summary>
public class GameView : BaseView
{
    // Events to attach to.
    public UnityAction OnPauseClicked;

    /// <summary>
    /// Method called by Pause Button.
    /// </summary>
    public void PauseClick()
    {
        OnPauseClicked?.Invoke();
    }

}