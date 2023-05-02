using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkeletonSword_Hitbox : MonoBehaviour
{
    public GameObject healthText;

    Collider2D SkeletonswordCollider;

    public float swordDamage = 2;

    private float knockbackForce = 8f;

    Vector3 OffsetY;

    private void Start()
    {
        SkeletonswordCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {          

            //Makes sure that the Offset on the y axis for the sprite center compared to the collider center for each of the damagable objects is taken in to accaount of the knockback calculation
            //And changes the knockback on different enemies
            if (collider.gameObject.tag == "player")
            {
                OffsetY = DamagableCharacter.PlayerOffsetY;
                knockbackForce = 75f;
            }
            if(collider.gameObject.tag == "slime")
            {
                OffsetY = DamagableCharacter.SlimeOffsetY;
                knockbackForce = 8f;
            }
            if (collider.gameObject.tag == "skeleton")
            {
                OffsetY = DamagableCharacter.SkeletonOffsetY;
                knockbackForce = 8f;
            }
            //Calculate direction between Skeleton and enemy
            Vector2 direction = (Vector2)((collider.gameObject.transform.position - OffsetY) - (transform.position - DamagableCharacter.SkeletonOffsetY)).normalized;
            Vector2 knockback = direction * knockbackForce;


            //Deal damage to enemy
            damageableObject.OnHit(swordDamage, knockback);

            
                //Instantiate damage text at the place where damage is being taken
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(collider.gameObject.transform.position);


                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            
            

        }


    }
}
