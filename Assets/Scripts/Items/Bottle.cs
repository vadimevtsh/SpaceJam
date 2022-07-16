using UnityEngine;

public class Bottle : Item
{
    public GameObject Player;
    
    public override void Use()
    {
        Player.GetComponent<SpaceMan>().CurrentOxygen += 20;
    }
}