using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for renewing the oxygen bar to maximum.
/// </summary>
public class ToMaxOxygen : Collidable
{
    public GameObject Player;
    public GameObject IconToPickUp;

    /// <summary>
    /// Method that sets oxygen level to maximum inside the ship when collision with the source.
    /// </summary>
    /// <param name="coll">Collider</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            IconToPickUp.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                IconToPickUp.SetActive(false);
                Player.GetComponent<SpaceMan>().currentOxygen = Player.GetComponent<SpaceMan>().maxOxygen;
            }
        }
        
    }
}
