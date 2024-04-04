using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UsernameValidator : MonoBehaviour
{
    public ValidateUser validateUser;
    public TMP_Text usernameText;
    public TMP_Text passwordText;

    public void Validate()
    {
        string username = usernameText.text;
        string password = passwordText.text;
        if (username.Length > 2 && password.Length > 2)
        {
            Debug.Log("Username: "+ username + "\nPassword: "+ password);
            validateUser.CheckInfo(username,password);
        }
        else
        {
            Debug.Log("El username y password tiene que ser mas de 3 o mas caracteres");
        }
    }

}
