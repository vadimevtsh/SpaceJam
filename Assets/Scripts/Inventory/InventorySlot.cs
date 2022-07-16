using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that represents a single inventory slot in the inventory.
/// </summary>
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    /// <summary>
    /// Method that adds item into the slot on the screen.
    /// </summary>
    /// <param name="newItem">item to be added</param>
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    /// <summary>
    /// Method that clears slot when the corresponding item is removed.
    /// </summary>
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    /// <summary>
    /// Method that removes item from the inventory.
    /// </summary>
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    /// <summary>
    /// Method that uses item from the inventory.
    /// </summary>
    public void UseItem()
    {
        item.Use();
        Inventory.instance.Remove(item);
    }

}
