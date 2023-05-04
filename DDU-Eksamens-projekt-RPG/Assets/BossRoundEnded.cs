using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoundEnded : MonoBehaviour
{
    public Collider2D col;
    void Update()
    {
        if(DamagableCharacter.enemiesDefeated > 6)
        {
            col.enabled = false;
        }
    }
}
