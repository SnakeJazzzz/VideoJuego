using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function is called when the "Play" button is pressed.
    public void PlayGame()
    {
       
        // Choose a random map index between 5 and 7 and load it additively
        int randomMapIndex = Random.Range(5, 8); // Random.Range is max-exclusive
        SceneManager.LoadScene(randomMapIndex);
        //SceneManager.LoadScene("Map2"); 
    }

    public void BuildDeck()
    {
        SceneManager.LoadScene("DeckBuilder");
    }

        public void BuildDeck()
    {
        SceneManager.LoadScene("DeckBuilder");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
