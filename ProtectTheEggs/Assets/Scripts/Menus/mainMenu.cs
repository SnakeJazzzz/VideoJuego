using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UserInformation userInformation;

    public void cambiarescena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

/*
    public void PlayGame()
    {
        if (userInformation.selectedDeck != -1)
        {
            int randomMapIndex = Random.Range(5, 8);
            SceneManager.LoadScene(randomMapIndex);
        }
        else
        {
            Debug.Log("No hay mazo seleccionado!");
        }

        // SceneManager.LoadScene("Map2"); 
    }

    public void BuildDeck()
    {
        SceneManager.LoadScene("DeckMenu");
    }

*/

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
