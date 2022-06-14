using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a classs that represents collectable objects.
/// </summary>
public class Collectable : Collidable
{
    protected bool _isCollected;

    /// <summary>
    /// Method that represents collecting items when collision with the character happens.
    /// </summary>
    /// <param name="coll">Collider.</param>
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
