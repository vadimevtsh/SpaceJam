using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for quitting the space ship.
/// </summary>
public class QuitSpaceShip : Collidable
{
    public GameObject iconToPickUp;
    public GameObject SpaceMan;
    private Vector3 _posToTeleport;

    /// <summary>
    /// Method that teleports the character out of the ship when collision with the door happens.
    /// </summary>
    /// <param name="coll">Collider.</param>
    protected override void OnCollide(Collider2D coll)
    {
        _posToTeleport = new Vector3(1.648f, 0.100f, -1f);
        if (coll.name == "spaceman")
        {
            iconToPickUp.SetActive(true);
        }
        if (coll.name == "spaceman" && Input.GetKeyDown("e"))
        {
            SpaceMan.transform.position = _posToTeleport;
        }
    }
}
