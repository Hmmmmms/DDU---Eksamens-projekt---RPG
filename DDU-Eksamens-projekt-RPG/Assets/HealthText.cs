using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{

    float timeToLive = 0.5f;
    float floatspeed = 200;

    public Vector3 floatdirection = new Vector3(0, 1, 0);

    public TextMeshProUGUI textMesh;

    float timeElapsed = 0.0f;

    RectTransform rTransform;

    Color startingColor; 
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        startingColor = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        rTransform.position += floatdirection * floatspeed * Time.deltaTime;

        textMesh.color = new Color (startingColor.r , startingColor.g, startingColor.b, 1 - timeElapsed / timeToLive);

        if(timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }

    }
}
