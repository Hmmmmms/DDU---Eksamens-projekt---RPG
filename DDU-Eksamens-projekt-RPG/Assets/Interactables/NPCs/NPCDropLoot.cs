using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDropLoot : MonoBehaviour
{

    public LootBag lootBag;
    public bool dropLoot = false;


    public static Vector3 NPClootDropOffset = new Vector3(0.1f, 0.0f, 0.0f);

    public void NPCdropLoot()
    {
        if (dropLoot)
        {
            lootBag.InstantiateLoot(transform.position + NPClootDropOffset);
            dropLoot = false;
        }
    }
}
