using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public ItemData lootData;
    public int dropchance;

    public Loot(string lootName, Sprite lootSprite,  int dropchance)
    {
        this.lootSprite = lootData.icon;
        this.lootName = lootData.displayName;
        this.dropchance = dropchance;
    }
}
