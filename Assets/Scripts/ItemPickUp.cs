using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Collidable
{
    public Item item;
    public GameObject iconToPickUp;
    bool wasPickedUp = false;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
            PickUp();
    }

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
