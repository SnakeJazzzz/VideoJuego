using UnityEngine;
using UnityEngine.SceneManagement;

public class mapsMenu : MonoBehaviour
{
    public UserInformation userInformation;
    public void cambiarescena(string escena)
    {
        if (userInformation.selectedDeck != -1)
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            Debug.Log("No hay mazo seleccionado!");
        }

    }

    public string GetCurrentMapName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
