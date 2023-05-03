using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBag : MonoBehaviour
{
    public List<Loot> lootlist = new List<Loot>();

    public static Vector3 lootDropOffset = new Vector3(0.0f, 0.1f, 0.0f);

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101); //1-100 chance;
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootlist)
        {
            if (randomNumber <= item.dropchance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }
    public void InstantiateLoot(Vector2 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();

        if (droppedItem != null)
        {
            

            GameObject lootGameObject = Instantiate(droppedItem.LootPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
