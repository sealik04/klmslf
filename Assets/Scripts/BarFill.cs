using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    private Slider slider;
    public Image fillImage;
    public PlayerController playerController;
    
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        
        float fillValue = playerController.currHealth  / playerController.playerMaxHealth;
        slider.value = fillValue;
    }
}
