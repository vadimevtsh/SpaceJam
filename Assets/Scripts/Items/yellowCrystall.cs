using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for placing crystal into the ship
/// </summary>
public class YellowCrystall : Collidable
{
    public GameObject crystallPrefab;
    public GameObject miniMap;
    public GameObject iconToPickUp;
    public Item item;
    

    /// <summary>
    /// Method that places crystal into the ship.
    /// </summary>
    /// <param name="coll">Collision</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman" && Inventory.instance.CheckItem("oxygenCrystall"))
        {
            iconToPickUp.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
            iconToPickUp.SetActive(false);
            Instantiate(Resources.Load<GameObject>("Prefabs/yellowCristal"), new Vector3(-13.169f, -2.95f, 0), Quaternion.identity);
            miniMap.SetActive(true);
            //remove from inv
            Inventory.instance.Remove(item);
            }
        }
    }
}
