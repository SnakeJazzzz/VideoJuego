using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class mapsMenu : MonoBehaviour
{
    public UserInformation userInformation;
    public GameObject textoMensajeNoMazo;
    public void cambiarescena(string escena)
    {
        if (userInformation.selectedDeck != -1)
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            StartCoroutine(MensajeNoMazo());
            Debug.Log("No hay mazo seleccionado!");
        }
    }

    public string GetCurrentMapName()
    {
        return SceneManager.GetActiveScene().name;
    }

    IEnumerator MensajeNoMazo()
    {
        textoMensajeNoMazo.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoMensajeNoMazo.SetActive(false);
    }
}
