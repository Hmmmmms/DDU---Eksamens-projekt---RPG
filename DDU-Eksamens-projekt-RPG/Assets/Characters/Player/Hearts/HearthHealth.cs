using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthHealth : MonoBehaviour
{
    public DamagableCharacter playerDamagableCharacter;

    private float _health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void Start()
    {
        playerDamagableCharacter = GetComponent<DamagableCharacter>();
    }
    public void Update()
    {
        _health = playerDamagableCharacter.health;

        if(_health > numOfHearts)
        {
            playerDamagableCharacter.health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < _health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }
}
