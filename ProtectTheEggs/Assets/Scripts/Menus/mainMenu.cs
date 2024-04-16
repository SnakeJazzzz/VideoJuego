using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UserInformation userInformation;
    // This function is called when the "Play" button is pressed.
    public void PlayGame()
    {
       
        // Choose a random map index between 5 and 7 and load it additively
        if (userInformation.selectedDeck != -1)
        {
            int randomMapIndex = Random.Range(5, 8); // Random.Range is max-exclusive
            SceneManager.LoadScene(randomMapIndex);
 
        }
        else
        {
            Debug.Log("No hay mazo seleccionado!");
        }
        //SceneManager.LoadScene("Map2"); 
    }

    public void BuildDeck()
    {
        SceneManager.LoadScene("DeckMenu");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
