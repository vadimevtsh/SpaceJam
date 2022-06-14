using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for something
/// </summary>
public class YellowCrystall : Collidable
{
    public GameObject crystallPrefab;
    public GameObject O2Bar;
    public GameObject iconToPickUp;

    /// <summary>
    /// Method that does something.
    /// </summary>
    /// <param name="coll">Collision</param>
    protected override void OnCollide(Collider2D coll)
    {
        iconToPickUp.SetActive(true);
        if (coll.name == "spaceman" && Inventory.instance.CheckItem("oxygenCrystall") && Input.GetKeyDown("e"))
        {
            iconToPickUp.SetActive(false);
            Instantiate(crystallPrefab, new Vector3(-13.169f, -2.806f, -6), Quaternion.identity);
            O2Bar.SetActive(true);
            //remove from inv
        }
    }
}
