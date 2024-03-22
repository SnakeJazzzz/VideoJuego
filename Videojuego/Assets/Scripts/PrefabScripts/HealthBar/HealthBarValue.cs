using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarValue : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float percentage)
    {
        slider.value = percentage;
    }
    
}
