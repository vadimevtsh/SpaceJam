using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for picking up different items.
/// </summary>
public class ItemPickUp : Collidable
{
    public Item item;
    public GameObject iconToPickUp;
    bool wasPickedUp = false;

    /// <summary>
    /// Method that picks up the item when collision happens.
    /// </summary>
    /// <param name="coll">Collider</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
            PickUp();
    }

    /// <summary>
    /// Method that picks up the item and adds it to the inventory.
    /// </summary>
    void PickUp()
    {
        iconToPickUp.SetActive(true);

        if (!wasPickedUp && Input.GetKeyDown("e"))
        {
            wasPickedUp = true;
            Inventory.instance.Add(item);
            iconToPickUp.SetActive(false);
            Destroy(gameObject);
        }
    }
}
