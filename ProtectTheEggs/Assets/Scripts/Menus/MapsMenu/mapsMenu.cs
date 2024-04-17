using UnityEngine;
using UnityEngine.SceneManagement;

public class mapsMenu : MonoBehaviour
{
    public void cambiarescena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
