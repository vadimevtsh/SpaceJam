using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool isCollected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        isCollected = true;
    }
}
