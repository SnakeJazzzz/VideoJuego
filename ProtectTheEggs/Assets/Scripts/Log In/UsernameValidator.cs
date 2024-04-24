using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UsernameValidator : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text passwordText;
    public Action<string, string> ValidUsername;
    public GameObject textoMensaje3caracteres;

    public void Validate()
    {
        string username = usernameText.text;
        string password = passwordText.text;
        if (username.Length > 3 && password.Length > 3)
        {
            Debug.Log("Username: "+ username + "\nPassword: "+ password);
            ValidUsername?.Invoke(username,password);
        }
        else
        {
            StartCoroutine(MensajeMensaje3caracteres());
            Debug.Log("El username y password tiene que ser más de 3 o mas caracteres");
        }
    }

    IEnumerator MensajeMensaje3caracteres()
    {
        textoMensaje3caracteres.SetActive(true);
        yield return new WaitForSeconds(3f);
        textoMensaje3caracteres.SetActive(false);
    }
}
