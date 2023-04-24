using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    Collider2D swordCollider;

    public float swordDamage = 3;

    public float knockbackForce = 100f;


    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
            IDamageable damageableObject = collider.GetComponent<IDamageable>();

            if (damageableObject != null)
            {
                //Calculate direction between player and slime
                Vector3 parentPosition = transform.parent.position;

                Vector3 OffsetY = new Vector3(0.0f, 0.1f, 0.0f);

                Vector2 direction = (Vector2)(collider.gameObject.transform.position - (parentPosition - OffsetY)).normalized;
                Vector2 knockback = direction * knockbackForce;


                //Deal damage to enemy
                print("SlimeDamage -" + swordDamage);
                damageableObject.OnHit(swordDamage, knockback);

            }
        else
        {
            print("Collider  does not implement IDamageable");
        }
        
    }
}