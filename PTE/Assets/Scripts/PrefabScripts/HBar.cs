using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBar : NPCSystem
{
    public TeamColors teamColors;
    [SerializeField] HealthBarValue healthBarValue;
    [SerializeField] HealthBarColor healthBarColor;
    
    void OnEnable()
    {
        healthBarValue = GetComponentInChildren<HealthBarValue>();
        healthBarColor = GetComponentInChildren<HealthBarColor>();
        
        healthBarColor.ChangeHBColor(teamColors.Items[npcController.owner]);
       
    }

    public void UpdateHB(float currentHealth)
    {
        healthBarValue.UpdateHealthBar(currentHealth / npcController.npcStats.health);
    }

  
}
