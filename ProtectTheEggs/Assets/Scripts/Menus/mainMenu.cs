using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UserInformation userInformation;

    public void cambiarescena(string escena)
    {
        SceneManager.LoadScene(escena);
    }


    
  

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
