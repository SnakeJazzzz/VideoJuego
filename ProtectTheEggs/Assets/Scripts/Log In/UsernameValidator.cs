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
    public GameObject TextoMensaje3caracteres;

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
            StartCoroutine(mensaje3caracateres());
            Debug.Log("El username y password tiene que ser mas de 3 o mas caracteres");
        }
    }

    IEnumerator mensaje3caracateres()
    {
        TextoMensaje3caracteres.SetActive(true);
        yield return new WaitForSeconds(2f);
        TextoMensaje3caracteres.SetActive(false);
    }
}
