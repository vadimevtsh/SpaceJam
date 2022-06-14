/// <summary>
/// This is base state script implementation.
/// State Machine operates using this states.
/// </summary>
public abstract class BaseState
{
    public StateMachine owner;

    /// <summary>
    /// Method called to prepare state to operate, same as Unity's Start()
    /// </summary>
    public virtual void PrepareState() { }

    /// <summary>
    /// Method called to update state on every frame, same as Unity's Update()
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Method called to destroy state,same as Unity's OnDestroy()
    /// </summary>
    public virtual void DestroyState() { }
}