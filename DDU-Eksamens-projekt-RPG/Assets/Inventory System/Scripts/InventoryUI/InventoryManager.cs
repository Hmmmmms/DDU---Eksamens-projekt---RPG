using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlots> _inventorySlots = new List<InventorySlots>(6);

    public bool isActiveAndEnabled;

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    private void ResetInventory()
    {
        foreach (Transform childtransform in transform)
        {
            Destroy(childtransform.gameObject);
        }
        _inventorySlots = new List<InventorySlots>(6);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        //Clear Inventory
        ResetInventory();

        //Create 6 empty slots
        for (int i = 0; i < _inventorySlots.Capacity; i++)
        {
            //create the 12 slots
            CreateInventoryslot();

        }
        //Loop through the inventory, and tell slots to update
        for(int i = 0; i < inventory.Count; i++)
        {
            _inventorySlots[i].DrawSlot(inventory[i]);
        }
        //If closed then open
        isActiveAndEnabled = true;
        Image inventoryPanel = transform.GetComponent<Image>();
        inventoryPanel.enabled = true;
    }
    void CreateInventoryslot()
    {
        GameObject newslot = Instantiate(slotPrefab);
        newslot.transform.SetParent(transform, false);

        InventorySlots newSlotComponent = newslot.GetComponent<InventorySlots>();
        newSlotComponent.ClearSlot();

        _inventorySlots.Add(newSlotComponent);
    }

    public void Show()
    {
        
        Image inventoryPanel = transform.GetComponent<Image>();
        inventoryPanel.enabled = true;


        foreach (Transform childtransform in transform)
        {
            childtransform.gameObject.SetActive(true);
        }
        isActiveAndEnabled = true;
    }

    public void Hide()
    {
        
        Image inventoryPanel = transform.GetComponent<Image>();
        inventoryPanel.enabled = false;


        foreach (Transform childtransform in transform)
        {
            childtransform.gameObject.SetActive(false);
        }
        isActiveAndEnabled = false;
    }

}
