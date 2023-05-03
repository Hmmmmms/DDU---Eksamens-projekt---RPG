using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private AudioSource PickUpSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if(collectable != null)
        {
            PickUpSound.Play();
            collectable.Collect();
        }
    }
}
