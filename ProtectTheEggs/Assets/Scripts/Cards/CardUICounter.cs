using UnityEngine;
using TMPro;

public class CardUICounter : MonoBehaviour
{
    public TextMeshProUGUI cardCountText; // Instancia del TextMeshProUGUI para el contador de cartas
    public CardSOSystem cardSystem; // Instancia del script CardSOSystem
    public int OriginalValue= 20;
    public int value;

    public void Awake()
    {
       Reset();
    }
    private void OnEnable()
    {
        cardSystem.GetNewCard += UpdateCardCount;
        cardSystem.ShuffleOverA += Reset;
    }

    private void OnDisable()
    {
        cardSystem.GetNewCard -= UpdateCardCount;
        cardSystem.ShuffleOverA += Reset;   
    }

    private void UpdateCardCount()
    {
        if (value == 0){return;}
        value--;
        cardCountText.text = value.ToString();
    }

    void Reset()
    {
        value = OriginalValue;
        cardCountText.text = value.ToString();
    }
}
    