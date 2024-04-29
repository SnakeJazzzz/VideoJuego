using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CardAdder : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    public UserInformation userInformation;
    List<MenuCard> menuCards;
    public GameObject CardContainer;
    public CardCounter cardCounter;
    public TMP_Text text;
    public GameObject TextoMensaje20cartas;
    public TMP_Text TextoCartasRestantes;
    public GameObject TextoMensajeNombreMazo;
    public string buttonClickSoundName;
    
    void Awake()
    {
       cardCounter = CardContainer.GetComponent<CardCounter>();
    }
   
    public void AddAllCardss()
    {
        if (!cardCounter.status) 
        {
            Debug.Log("Tienes que seleccionar " + cardCounter.deckSize + " cartas.");
            TextoCartasRestantes.text = "You need to add " + cardCounter.deckSize + " cards!";
            StartCoroutine(mensaje20cartas());
            SoundManager.Instance.PlaySFXByName("MenosCarta");
            return;
        
        }
       
        if (text.text.Length == 1)
        {
            Debug.Log("Tienes que seleccionar un nombre para el mazo.");
            StartCoroutine(mensajeNombreMazo());
            SoundManager.Instance.PlaySFXByName("MenosCarta");
            return;
        }
        string name = text.text.Substring(0, text.text.Length-1);

        menuCards = CardContainer.GetComponentsInChildren<MenuCard>().ToList();
        deckBuilderManager.MazoSeleccionado.cards.Clear();
        deckBuilderManager.MazoSeleccionado.username = userInformation.username;
        deckBuilderManager.MazoSeleccionado.nombreMazo = name;

        for (int i = 0; i < menuCards.Count; i++)
        {
            if (menuCards[i].value > 0)
            {
                deckBuilderManager.MazoSeleccionado.cards.Add(new CardData(menuCards[i].value, menuCards[i].cardData.ID));
            }
        }

        if (deckBuilderManager.CreateOrEdit)
        {
            deckBuilderManager.StartPost?.Invoke();
        }
        else
        {
            deckBuilderManager.StartPut?.Invoke();
        }
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }

    IEnumerator mensaje20cartas()
    {
        TextoMensaje20cartas.SetActive(true);
        yield return new WaitForSeconds(2f);
        TextoMensaje20cartas.SetActive(false);
    }

    IEnumerator mensajeNombreMazo()
    {
        TextoMensajeNombreMazo.SetActive(true);
        yield return new WaitForSeconds(2f);
        TextoMensajeNombreMazo.SetActive(false);
    }
}
