using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool _isCollected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        _isCollected = true;
    }
}
