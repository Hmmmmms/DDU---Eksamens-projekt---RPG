using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject LootPrefab;
    public int dropchance;

    public Loot(GameObject LootPrefab, int dropchance)
    {
        this.LootPrefab = LootPrefab;
        this.dropchance = dropchance;
    }
}
