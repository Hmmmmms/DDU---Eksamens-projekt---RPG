using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LostHeart : MonoBehaviour, ICollectable
{
    public static event HandleLostHeartCollected OnLostHeartCollected;
    public delegate void HandleLostHeartCollected(ItemData itemData);
    public ItemData LostHeartData;

    public void Collect()
    {

        Destroy(gameObject);

        OnLostHeartCollected?.Invoke(LostHeartData);
    }
}