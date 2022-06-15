using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for managing inventory User Interface.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    
    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    /// <summary>
    /// Method that shows items from the inventory on the screen.
    /// </summary>
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
