using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for dropping down the oxygen level.
/// </summary>
public class OxygenStop : Collidable
{
    public GameObject Player;

    /// <summary>
    /// Method that sets default oxygen raise down to zero when entering spaceship.
    /// </summary>
    /// <param name="coll">Collider</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            Player.GetComponent<SpaceMan>().defaultOxygenRaiseDown = 0;
        }
    }
}
