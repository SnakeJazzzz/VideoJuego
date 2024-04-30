using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
     [SerializeField] private GameObject optionsPanel; // Assign your options panel in the inspector
     public string buttonPauseSoundName;
     public string buttonResumeSoundName;
     public string buttonMenuSoundName;

    private void Start()
    {
        // Ensure the options panel is not active when the game starts
        //optionsPanel.SetActive(false);
    }

    // This function is called when the pause button is pressed.
    public void TogglePauseMenu()
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
            Debug.Log("Resume");
            
        }
        else
        {
            PauseGame();
            Debug.Log("Pause"); 
            
        }
     
        
    }

    public void PauseGame(){
        bool isPaused = Time.timeScale == 0;
        Time.timeScale = isPaused ? 1 : 0; // Toggle the time scale to pause or unpause the game
        optionsPanel.SetActive(true); // Toggle the visibility of the options panel
        SoundManager.Instance.PlaySFXByName(buttonPauseSoundName);


    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        optionsPanel.SetActive(false); // Hide the options panel
        SoundManager.Instance.PlaySFXByName(buttonResumeSoundName);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the time scale is reset to resume normal game speed
        // The following line should load the main menu scene, not additively but as the main scene to clear the current game state.
        SceneManager.LoadScene("Menu");  // Replace "Menu" with the exact name of your main menu scene
        SoundManager.Instance.PlaySFXByName(buttonMenuSoundName);
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the game
        SoundManager.Instance.PlaySFXByName(buttonResumeSoundName);
    }
}
