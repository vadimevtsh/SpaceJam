using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that represents a single item.
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    /// <summary>
    /// Method that uses specific item.
    /// </summary>
    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
