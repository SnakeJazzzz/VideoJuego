using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cost;
    public int numberOfNPCs;
    public NPCStats stats;
    public Sprite artwork;
    public GameObject prefab;
}
