using UnityEngine;

public class Bottle : Item
{
    public GameObject Player;
    public static Bottle instance;

    private bool _isFull;
    
    public bool IsFull
    {
        get => _isFull;

        set => _isFull = value;
    }

    /*private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(">1 instance of Bottle found");
            return;
        }
        instance = this;
    }*/
    public override void Use()
    {
        Debug.Log("bottle is " + _isFull);
        if (_isFull)
        {
            Player.GetComponent<SpaceMan>().CurrentOxygen = Player.GetComponent<SpaceMan>().MaxOxygen;

            _isFull = false;
        }
    }
}