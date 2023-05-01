using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable
{
    public static event HandleHealthPotionCollected OnHealthPotionCollected;
    public delegate void HandleHealthPotionCollected(ItemData itemData);
    public ItemData HealthPotionData;

    public void Collect()
    {

        Destroy(gameObject);

        OnHealthPotionCollected?.Invoke(HealthPotionData);
    }

}
