using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private readonly int _space = 4; // it was just public
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;


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

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

    public bool CheckItem(string name)
    {
        foreach (Item itm in items)
            if (name == itm.name)
                return true;
        return false;
    }
}
