using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectable
{
    public static event HandleKeyCollected OnKeyCollected;
    public delegate void HandleKeyCollected(ItemData itemData);
    public ItemData KeyData;

    public void Collect()
    {

        Destroy(gameObject);

        OnKeyCollected?.Invoke(KeyData);
    }
}
