using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public UsernameValidator usernameValidator;
    public void ValidateInfo()
    {
        usernameValidator.Validate();
    }
    public void CreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
     public void DeckMenu()
    {
        SceneManager.LoadScene("DeckMenu");
    }
}
