using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionText : MonoBehaviour
{

    public TextMeshProUGUI potionText;
    int potionCount;


    private void OnEnable()
    {
        //HealthPotion.OnPotionCollected += IncrementPotionCount;
    }

    private void OnDisable()
    {
        //HealthPotion.OnPotionCollected -= IncrementPotionCount;
    }

    public void IncrementPotionCount()
    {
        potionCount++;
        potionText.text = $"Potions:{potionCount}";
    }
}
