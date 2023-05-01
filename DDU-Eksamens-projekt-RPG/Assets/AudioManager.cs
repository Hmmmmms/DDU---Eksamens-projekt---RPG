using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;


    [SerializeField] AudioClip Collectionsound, pickupSound;

    private void OnEnable()
    {
        //HealthPotion.OnPotionCollected += PlayPickupSound;
        //Sword.OnSwordCollected += PlayPickupSound;
        //Shield.OnShieldCollected += PlayPickupSound;
        //ManaPotion.OnManaPotionCollected += PlayPickupSound;
    }

    private void OnDisable()
    {
        //HealthPotion.OnPotionCollected -= PlayPickupSound;
        //Sword.OnSwordCollected -= PlayPickupSound;
        //Shield.OnShieldCollected -= PlayPickupSound;
        //ManaPotion.OnManaPotionCollected -= PlayPickupSound;
    }

    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Destroy(this); 
        }
        else
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayPickupSound()
    {
        //Fetch the pickup sound
        //PlayAudioClip(pickupSound);

    }

}
