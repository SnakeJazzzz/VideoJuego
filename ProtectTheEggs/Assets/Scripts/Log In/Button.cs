using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public UsernameValidator usernameValidator;
    public UserInformation userInformation;
    public string buttonClickSoundName;
    
    public void ValidateInfo()
    {
        usernameValidator.Validate();
        //-----
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
        //-----
    }
    
    public void CreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");

        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);

    }
    
    public void LogInScene()
    {
        SceneManager.LoadScene("LogIn");

        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);

    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }
    
    public void DeckMenu()
    {
        SceneManager.LoadScene("DeckMenu");
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }
    public void MenuAndUnselect()
    {
        userInformation.selectedDeck = -1;
        SceneManager.LoadScene("DeckMenu");
    }
}
