using UnityEngine;

[CreateAssetMenu(fileName = "PartidaInfo", menuName = "PartidaInfo")]
public class PartidaInfo : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    
    public GameSessionData currentSession;

    public void Reset()
    {
        currentSession.username = null;
        currentSession.NombreMapa = null;
        currentSession.MaxOrda = null;
    }
}

[System.Serializable]
public class GameSessionData
{
    public string NombreMapa;
    public string MaxOrda;
    public string username;
}

