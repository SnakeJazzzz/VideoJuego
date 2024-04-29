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
    public string buttonClickSoundName;
    public string soundNoMaso;
    public string soundMapa;
    public void cambiarescena(string escena)
    {
        if (userInformation.selectedDeck != -1)
        {
            SceneManager.LoadScene(escena);
            SoundManager.Instance.PlaySFXByName(soundMapa);
        }
        else
        {
            StartCoroutine(MensajeNoMazo());
            Debug.Log("No hay mazo seleccionado!");
            SoundManager.Instance.PlaySFXByName(soundNoMaso);
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
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
