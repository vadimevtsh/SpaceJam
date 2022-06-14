using UnityEngine;

/// <summary>
/// Menu state that shows Menu view and adds user interactions with the view.
/// </summary>
public class MenuState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.MenuView.OnStartClicked += StartClicked;
        owner.UI.MenuView.OnQuitClicked += QuitClicked;
        //owner.UI.MenuView.OnSettingsClicked += SettigsClicked;

        // Show menu view
        owner.UI.MenuView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide menu view
        owner.UI.MenuView.HideView();

        // Detach functions from view events
        owner.UI.MenuView.OnStartClicked -= StartClicked;
        owner.UI.MenuView.OnQuitClicked -= QuitClicked;
        //owner.UI.MenuView.OnSettingsClicked -= SettingsClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Start button is clicked in Menu view.
    /// </summary>
    private void StartClicked()
    {
        owner.ChangeState(new GameState());
    }

    /// <summary>
    /// Function called when Quit button is clicked in Menu view.
    /// </summary>
    private void QuitClicked()
    {
        Application.Quit();
    }

}