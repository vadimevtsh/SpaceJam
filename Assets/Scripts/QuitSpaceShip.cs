using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSpaceShip : Collidable
{
    public GameObject iconToPickUp;
    public GameObject SpaceMan;
    private Vector3 posToTeleport;

    protected override void OnCollide(Collider2D coll)
    {
        posToTeleport = new Vector3(1.648f, 0.100f, -1f);
        if (coll.name == "spaceman")
        {
            iconToPickUp.SetActive(true);
        }
        if (coll.name == "spaceman" && Input.GetKeyDown("e"))
        {
            SpaceMan.transform.position = posToTeleport;
        }
    }
}
