using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, ICollectable
{
    public static event HandleShieldCollected OnShieldCollected;
    public delegate void HandleShieldCollected(ItemData itemData);
    public ItemData ShieldData;

    public void Collect()
    {

        Destroy(gameObject);

        OnShieldCollected?.Invoke(ShieldData);
    }
}
