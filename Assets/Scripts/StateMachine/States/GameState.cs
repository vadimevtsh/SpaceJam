using UnityEngine;

/// <summary>
/// This is example of game state.
/// It shows game view and can load some content related to gameplay.
/// </summary>
public class GameState : BaseState
{
    // Variables used for loading and destroying game content
    public bool loadGameContent = true;
    public bool destroyGameContent = true;

    // Used when player decides to go to menu from pause state
    public bool skipToFinish = false;

    public override void PrepareState()
    {
        base.PrepareState();


        // Attach functions to view events
        owner.UI.GameView.OnPauseClicked += PauseClicked;

        // Show game view
        owner.UI.GameView.ShowView();

        if (loadGameContent)
        {
            // load game content
            
        }
    }

    public override void DestroyState()
    {
        if (destroyGameContent)
        {
            // destroy loaded game content
        }

        // Hide game view
        owner.UI.GameView.HideView();

        // Detach functions from view events
        owner.UI.GameView.OnPauseClicked -= PauseClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Pause button is clicked in Game view.
    /// </summary>
    private void PauseClicked()
    {
        destroyGameContent = false;

        owner.ChangeState(new PauseState());
    }

}