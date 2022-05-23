using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMaxOxygen : Collidable
{
    public GameObject Player;
    public GameObject IconToPickUp;

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
