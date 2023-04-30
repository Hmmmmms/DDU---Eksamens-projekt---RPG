using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public GameObject healthText;

    public float damage = 1f;

    private float knockbackForce = 10f;

    Vector3 OffsetY;

    void Start()
    {
        
    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {

            //Makes sure that the Offset on the y axis for the sprite center compared to the collider center for each of the damagable objects is taken in to accaount of the knockback calculation 
            if (collider.gameObject.tag == "player")
            {
                OffsetY = DamagableCharacter.PlayerOffsetY;
                knockbackForce = 100f;
            }
            if (collider.gameObject.tag == "slime")
            {
                OffsetY = DamagableCharacter.SlimeOffsetY;
                knockbackForce = 10f;
            }
            if (collider.gameObject.tag == "skeleton")
            {
                OffsetY = DamagableCharacter.SkeletonOffsetY;
                knockbackForce = 5f;
            }


            //Calculate direction between player and slime
            Vector2 direction = (Vector2)((collider.gameObject.transform.position - OffsetY) - (transform.position - DamagableCharacter.SlimeOffsetY)).normalized;
            Vector2 knockback = direction * knockbackForce;

            //Deal Damage
            damageable.OnHit(damage, knockback);

            //Instantiate damage text at the place where damage is being taken
            RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
            textTransform.transform.position = Camera.main.WorldToScreenPoint(collider.gameObject.transform.position);


            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            textTransform.SetParent(canvas.transform);


        }
    }
}
