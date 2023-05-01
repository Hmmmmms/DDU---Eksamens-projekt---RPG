using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();



    private void OnEnable()
    {
        HealthPotion.OnHealthPotionCollected += Add;
        ManaPotion.OnManaPotionCollected += Add;
        Sword.OnSwordCollected += Add;
        Shield.OnShieldCollected += Add;
    }
    private void OnDisable()
    {
        HealthPotion.OnHealthPotionCollected -= Add;
        ManaPotion.OnManaPotionCollected -= Add;
        Sword.OnSwordCollected -= Add;
        Shield.OnShieldCollected -= Add;
    }


    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory for the first time");
            OnInventoryChange?.Invoke(inventory);
        }
    }


    public void remove(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }

    
}
