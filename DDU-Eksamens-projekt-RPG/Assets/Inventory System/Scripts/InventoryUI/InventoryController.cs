using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static event HandleHealthPotionUsed OnHealthPotionUsed;
    public delegate void HandleHealthPotionUsed(ItemData itemData);

    [SerializeField]
    private InventoryManager inventoryUI;

    [SerializeField]
    private Inventory _inventoryAcces; 

    public DamagableCharacter playerDamagableCharacter;

    

    public HearthHealth MaxHealth;

    public ItemData HealthPotionData;

    private int numOfHealthPotions = 0;

    private void OnEnable()
    {
        HealthPotion.OnPickupAddPotionToPotions += AddnumOfHealthPotions;
        
    }
    private void OnDisable()
    {
        HealthPotion.OnPickupAddPotionToPotions -= AddnumOfHealthPotions;

    }

    public void Start()
    {
        playerDamagableCharacter = GetComponent<DamagableCharacter>();
        _inventoryAcces = GetComponent<Inventory>();
        MaxHealth = GetComponent<HearthHealth>();
        inventoryUI.isEnabled = false;
    }

    public void Update()
    {
        if (playerDamagableCharacter.isAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (inventoryUI.isEnabled == false)
                {
                    inventoryUI.Show();

                }
                else
                {
                    inventoryUI.Hide();
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (numOfHealthPotions > 0 && playerDamagableCharacter.health != MaxHealth.numOfHearts)
                {

                    RemovenumOfHealthPotions();
                    playerDamagableCharacter.health++;

                    OnHealthPotionUsed?.Invoke(HealthPotionData);
                }
                else
                {
                    if (numOfHealthPotions == 0)
                    {
                        Debug.Log("No Health Potions");
                    }
                    if (playerDamagableCharacter.health == MaxHealth.numOfHearts)
                    {
                        Debug.Log("Already max Health");
                    }

                }
            }
        }
        else
        {
            if (inventoryUI.isEnabled == true)
            {
                inventoryUI.Hide();
            }
        }
    }

    public void AddnumOfHealthPotions()
    {
        numOfHealthPotions++;
    }

    public void RemovenumOfHealthPotions()
    {
        numOfHealthPotions--;
    }
}
