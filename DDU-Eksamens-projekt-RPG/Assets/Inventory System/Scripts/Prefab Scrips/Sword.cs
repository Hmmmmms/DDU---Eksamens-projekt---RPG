using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, ICollectable
{
    public static event HandleSwordCollected OnSwordCollected;
    public delegate void HandleSwordCollected(ItemData itemData);
    public ItemData SwordData;

    public void Collect()
    {

        Destroy(gameObject);

        OnSwordCollected?.Invoke(SwordData);


    }
}
