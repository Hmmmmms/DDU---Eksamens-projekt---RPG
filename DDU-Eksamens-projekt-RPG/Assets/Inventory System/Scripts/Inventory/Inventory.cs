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
        InventoryController.OnHealthPotionUsed += remove;

        Key.OnKeyCollected += Add;
        InventoryController.OnDoorKeyUsed += remove;
        Brick.OnBrickCollected += Add;

        Sword.OnSwordCollected += Add;
        Shield.OnShieldCollected += Add;

        LostHeart.OnLostHeartCollected += Add;
    }
    private void OnDisable()
    {
        HealthPotion.OnHealthPotionCollected -= Add;
        InventoryController.OnHealthPotionUsed -= remove;

        Key.OnKeyCollected -= Add;
        InventoryController.OnDoorKeyUsed -= remove;
        Brick.OnBrickCollected -= Add;

        Sword.OnSwordCollected -= Add;
        Shield.OnShieldCollected -= Add;

        LostHeart.OnLostHeartCollected -= Add;
    }


    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
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
