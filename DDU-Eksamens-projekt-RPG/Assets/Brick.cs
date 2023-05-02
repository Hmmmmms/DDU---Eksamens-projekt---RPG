using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, ICollectable
{
    public static event HandleBrickCollected OnBrickCollected;
    public delegate void HandleBrickCollected(ItemData itemData);
    public ItemData BrickData;

    public void Collect()
    {

        Destroy(gameObject);

        OnBrickCollected?.Invoke(BrickData);
    }
}
