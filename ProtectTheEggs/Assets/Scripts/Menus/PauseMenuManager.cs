using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
     [SerializeField] private GameObject optionsPanel; // Assign your options panel in the inspector

    private void Start()
    {
        // Ensure the options panel is not active when the game starts
        //optionsPanel.SetActive(false);
    }

    // This function is called when the pause button is pressed.
    public void TogglePauseMenu()
    {
        bool isPaused = Time.timeScale == 0;
        Time.timeScale = isPaused ? 1 : 0; // Toggle the time scale to pause or unpause the game
        optionsPanel.SetActive(!isPaused); // Toggle the visibility of the options panel
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        optionsPanel.SetActive(false); // Hide the options panel
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the time scale is reset to resume normal game speed
        // The following line should load the main menu scene, not additively but as the main scene to clear the current game state.
        SceneManager.LoadScene("Menu");  // Replace "Menu" with the exact name of your main menu scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the game
    }
}
