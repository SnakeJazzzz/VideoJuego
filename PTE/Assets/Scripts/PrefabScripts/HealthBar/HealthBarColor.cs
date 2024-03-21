using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarColor : MonoBehaviour
{
    [SerializeField] Image image;
    
     public void ChangeHBColor(Color color)
    {
        image.color = color;
    }
}
