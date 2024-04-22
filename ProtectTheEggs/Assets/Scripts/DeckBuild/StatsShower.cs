using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsShower : MonoBehaviour
{
    public TMP_Text statsText;
    public GameObject panel;
    string statsString;

    public void ShowStats(Card card)
    {
        panel.SetActive(true);
        statsString = "";
        statsString += card.cardName + "\n\n";
        statsString += card.description + "\n";
        statsString += "Cost: " + card.cost + "\n";
        statsString += "Number of NPCs: " + card.numberOfNPCs + "\n";


        statsString += "Health: " + card.stats.health + "\n";
        statsString += "Speed: " + card.stats.speed.ToString("F2") + "\n"; // Assuming you want to format the float with 2 decimal places
        statsString += "Attack: " + card.stats.attack + "\n";
        statsString += "Attack Cooldown: " + card.stats.attackCooldown.ToString("F2") + "\n"; // Formatting float with 2 decimal places
        statsString += "Range: " + card.stats.range.ToString("F2") + "\n"; // Formatting float with 2 decimal places
        statsString += "Is Structure: " + (card.stats.isStructure ? "Yes" : "No") + "\n";
        statsString += "Attack Towers: " + (card.stats.attackTowers ? "Yes" : "No") + "\n";
        statsString += "Attack Enemies: " + (card.stats.attackEnemies ? "Yes" : "No") + "\n";
        
        statsText.text = statsString;


    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }
    
}
