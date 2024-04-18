using UnityEngine;
using UnityEngine.SceneManagement;

public class mapsMenu : MonoBehaviour
{
    public void cambiarescena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public string GetCurrentMapName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
