using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float stamina;
    public float maxStamina;
    public bool CanUseStamina = true;

    public Slider _staminaBar;
    public Image _staminaBarFill;
    private Color StaminaColor;
    public Color DepletedStaminaColor;

    public float decresValue;
    void Start()
    {
        CanUseStamina = true;
        maxStamina = stamina;

        _staminaBar.maxValue = maxStamina;

        StaminaColor = _staminaBarFill.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (stamina > maxStamina) stamina = maxStamina;
        else if (stamina < 0) stamina = 0;

        else if (stamina != maxStamina)
        {
            IncreaseEnergy();
        }

        if (stamina == maxStamina)
        {
            CanUseStamina = true;
        }

        if (stamina == 0)
        {
            CanUseStamina = false;
        }

        if (CanUseStamina == false)
        {
            _staminaBarFill.color = StaminaColor + DepletedStaminaColor;
        }
        else
        {
            _staminaBarFill.color = StaminaColor;
        }


        _staminaBar.value = stamina;
    }

    public void DecreaseEnergy()
    {
        if(stamina !> 0)
        {
            stamina -= decresValue * Time.deltaTime;
        }
    }
    public void IncreaseEnergy()
    {
        stamina += decresValue/4 * Time.deltaTime;
        
    }
    
}
