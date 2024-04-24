using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLocal : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    public UserInformation userInformation;
    public RSCards AvailableCards;
    public RSRSCards mazos;

    void OnEnable()
    {
        deckBuilderManager.SavedInDB += Save;
    }

     void OnDisable()
    {
        deckBuilderManager.SavedInDB -= Save;
    }

    void Save(int id)
    {
        DeckData deckData = deckBuilderManager.MazoSeleccionado;
        RSCards mazoNuevo =  mazos.Items[userInformation.selectedDeck];

        mazoNuevo.nombreMazo = deckData.nombreMazo;

        if(deckBuilderManager.CreateOrEdit)
       {mazoNuevo.ID = id;}
        
        mazoNuevo.Items.Clear();
        for (int i = 0;i < deckData.cards.Count ;i++)
        {
            Card toAdd = AvailableCards.Items.Find(x => x.ID == deckData.cards[i].IDCarta); 
            for (int j = 0; j < deckData.cards[i].Cantidad; j++)
            {
                mazoNuevo.Items.Add(toAdd);
            }
        }
         SceneManager.LoadScene("DeckMenu");
    }
}
