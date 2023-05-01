using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour, ICollectable
{
    public static event HandleManaPotionCollected OnManaPotionCollected;
    public delegate void HandleManaPotionCollected(ItemData itemData);
    public ItemData ManaPotionData;

    public void Collect()
    {

        Destroy(gameObject);

        OnManaPotionCollected?.Invoke(ManaPotionData);
    }
}
