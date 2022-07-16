using UnityEngine;

/// <summary>
/// State Machine design pattern implementation.
/// Uses BaseState as base class for storing currently operating state.
/// </summary>
public class StateMachine : MonoBehaviour
{

    private BaseState currentState;

    // Reference to UI root
    [SerializeField]
    private UIRoot ui;
    public UIRoot UI => ui;

    /// <summary>
    /// Unity method called on the first frame
    /// </summary>
    private void Start()
    {
        // Start game in menu state
        ChangeState(new MenuState());
    }

    /// <summary>
    /// Unity method called on each frame
    /// </summary>
    private void Update()
    {

        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    /// <summary>
    /// Method used to change state
    /// </summary>
    /// <param name="newState">New state.</param>
    public void ChangeState(BaseState newState)
    {
        
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        // Swap reference
        currentState = newState;

        // If we have a new state, we should assign its owner and initialize this state
        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}
