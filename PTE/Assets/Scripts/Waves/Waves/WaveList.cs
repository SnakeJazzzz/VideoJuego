using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Waves/WaveList", fileName = "WaveList")]
public class WaveList : ScriptableObject
{
    public List<Wave> Waves;
}
