using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElixirUI : MonoBehaviour
{   
    public Elixir elixir;
    public Slider slider;
    public Text valueText;

    void OnEnable()
    {
        elixir.UpdateUI += UpdateData;
    }

     void OnDisable()
    {
        elixir.UpdateUI -= UpdateData;
    }

    public void UpdateData(int value, int limit)
    {
        //Debug.Log("Value: " + value +"\nLimit: "+ limit+"\nPercentage: "+ (float)value / limit);
        slider.value = (float)value / limit;
        valueText.text = value.ToString();
    }   
}