using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            print("PlayerDamage -1");
            //Deal damage to enemy
            PlayerController Player = other.GetComponent<PlayerController>();

            if (Player != null)
            {
                Player.PlayerHealth -= damage;
            }
        }
    }
}
