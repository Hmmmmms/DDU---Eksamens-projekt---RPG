using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{

    private string tagtarget = "player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    public Collider2D col; 


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == tagtarget)
        {
        detectedObjs.Add(collider);
        }

        
        
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagtarget)
        {
            detectedObjs.Remove(collider);
        }

    }

}
