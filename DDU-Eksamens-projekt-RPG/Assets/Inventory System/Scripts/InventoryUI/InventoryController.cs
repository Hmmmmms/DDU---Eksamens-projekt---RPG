using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private AudioSource UseKeySound;
    [SerializeField] private AudioSource UsePotionSound;
    [SerializeField] private AudioSource OpenInventorySound;
    //Sounds


    [SerializeField]
    private InventoryManager inventoryUI;

    [SerializeField]
    private Inventory _inventoryAcces; 

    public DamagableCharacter playerDamagableCharacter;
    
    //HealthPotion consumption Variables
    public HearthHealth MaxHealth;

    public ItemData HealthPotionData;

    private int numOfHealthPotions = 0;
    public static event HandleHealthPotionUsed OnHealthPotionUsed;
    public delegate void HandleHealthPotionUsed(ItemData itemData);

    //DoorKey Variables
    public int keyCount;

    public ItemData DoorKeyData;

    public static event HandleDoorKeyDataUsed OnDoorKeyUsed;
    public delegate void HandleDoorKeyDataUsed(ItemData itemData);

    private void OnEnable()
    {
        HealthPotion.OnPickupAddPotionToPotions += AddnumOfHealthPotions;
        Key.OnDoorKeyAcquired += AddDoorKey;


    }
    private void OnDisable()
    {
        HealthPotion.OnPickupAddPotionToPotions -= AddnumOfHealthPotions;
        Key.OnDoorKeyAcquired -= AddDoorKey;
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
            //InventoryUI toggle
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (inventoryUI.isEnabled == false)
                {
                    inventoryUI.Show();
                    OpenInventorySound.Play();
                }
                else
                {
                    inventoryUI.Hide();
                    OpenInventorySound.Play();
                }
            }
            //HealthPotion Consumption
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

        //Key Aquired

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

    public void AddDoorKey()
    {
        keyCount++;
        Debug.Log("DoorKey acquired");
    }

    public void UseDoorKey()
    {
        UseKeySound.Play();
        keyCount--;
        OnDoorKeyUsed?.Invoke(DoorKeyData);
    }
}
