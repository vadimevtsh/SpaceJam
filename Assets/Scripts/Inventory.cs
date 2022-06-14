using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that represents inventory object(sigleton).
/// </summary>
public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(">1 instance of Inv found");
            return;
        }
        instance = this;
    }
    #endregion

    private readonly int _space = 4; // The number of slots in the inventory
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    /// <summary>
    /// Method that adds item to the inventory if there is enough space.
    /// </summary>
    /// <param name="item">item to be added to the inventory</param>
    public void Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= _space)
            {
                Debug.Log("Not enough room");
                return;
            }
            items.Add(item);

            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
    }

    /// <summary>
    /// Method that removes item from the inventory.
    /// </summary>
    /// <param name="item">item to be removed from the inventory</param>
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

    /// <summary>
    /// Method that checks if the given item is present in the inventory.
    /// </summary>
    /// <param name="name">name of the item to be looking for</param>
    /// <returns>True, if the item is found. No, otherwise.</returns>
    public bool CheckItem(string name)
    {
        foreach (Item itm in items)
            if (name == itm.name)
                return true;
        return false;
    }
}
