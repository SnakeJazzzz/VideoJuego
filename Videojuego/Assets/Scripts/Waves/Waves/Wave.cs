using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Waves/New Wave", fileName = "Wave")]
public class Wave : ScriptableObject
{
    public List<EnemyInfo> WaveInformation;

}