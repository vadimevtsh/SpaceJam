using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that represents collisions.
/// </summary>
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D _boxCollider;
    private Collider2D[] _hits = new Collider2D[10];

    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();    
    }

    /// <summary>
    /// This is Unity's MonoBehaviour method that is called every frame.
    /// </summary>
    protected virtual void Update()
    {
        _boxCollider.OverlapCollider(filter, _hits);
        for (int i = 0; i < _hits.Length; i++)
        {
            if (_hits[i] == null)
                continue;

            OnCollide(_hits[i]);

            _hits[i] = null;
        }
    }

    /// <summary>
    /// Virtual method that represents collisions. To be overriden in the child classes.
    /// </summary>
    /// <param name="coll">Collider</param>
    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
