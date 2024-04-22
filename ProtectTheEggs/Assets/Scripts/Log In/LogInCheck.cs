
[System.Serializable]
public class LogInCheck
{
    public bool Success;
    public string Error;
    // Add other fields expected from your JSON data.
}

[System.Serializable]
public class DeckUpload
{
    public bool Success;
    public int DeckID;
    public string Error;
    // Add other fields expected from your JSON data.
}
