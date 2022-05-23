using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStop : Collidable
{
    public GameObject Player;
    private float currentOxygen;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            Player.GetComponent<SpaceMan>().defaultOxygenRaiseDown = 0;
        }
    }
}
