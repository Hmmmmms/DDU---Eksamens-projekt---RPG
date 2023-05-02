using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public GameObject damageText;

    Collider2D swordCollider;

    public float swordDamage = 3;

    private float knockbackForce = 8f;

    Vector3 OffsetY;

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

            //Makes sure that the Offset on the y axis for the sprite center compared to the collider center for each of the damagable objects is taken in to accaount of the knockback calculation
            if (collider.gameObject.tag == "slime")
            {
                OffsetY = DamagableCharacter.SlimeOffsetY;
            }
            if (collider.gameObject.tag == "skeleton")
            {
                OffsetY = DamagableCharacter.SkeletonOffsetY;
            }

                Vector2 direction = (Vector2)((collider.gameObject.transform.position - OffsetY) - (parentPosition - DamagableCharacter.PlayerOffsetY)).normalized;
                Vector2 knockback = direction * knockbackForce;


                //Deal damage to enemy
                damageableObject.OnHit(swordDamage, knockback);

                //Instantiate damage text at the place where damage is being taken
                RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(collider.gameObject.transform.position);


                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }
        
        
    }
}