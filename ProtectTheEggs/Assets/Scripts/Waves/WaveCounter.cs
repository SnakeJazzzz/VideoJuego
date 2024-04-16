using UnityEngine;
using TMPro; // Make sure to include the TextMeshPro namespace

public class WaveCounter : MonoBehaviour
{
    public TextMeshProUGUI waveNumberText; // Reference to the TextMeshProUGUI component
    public WaveList waveList; // Reference to the WaveList scriptable object
    private int currentWaveIndex = 0; // Keeps track of the current wave index

    private void Start()
    {
        // Find the TextMeshProUGUI component in the GUI scene.
        waveNumberText = GameObject.FindWithTag("WaveNumber").GetComponent<TextMeshProUGUI>();
        if (waveNumberText == null)
        {
            Debug.LogError("WaveCounter: Failed to find the Wave Number TextMeshProUGUI component in the scene.");
            return;
        }
        // Initialize the wave number text at the start of the game.
        UpdateWaveNumberText();
    }

    public void OnWaveCompleted()
    {
        // Re-find the TextMeshProUGUI component in case it's lost (due to scene unload/    load).
        if (waveNumberText == null)
        {
            waveNumberText = GameObject.FindWithTag("WaveNumber").    GetComponent<TextMeshProUGUI>();
            if (waveNumberText == null)
            {
                Debug.LogError("WaveCounter: Failed to find the Wave Number     TextMeshProUGUI component after completing a wave.");
                return;
            }
        }

        // Increment the wave index since a wave is completed
        currentWaveIndex++;

        // Update the wave number text UI
        UpdateWaveNumberText();
    }

    

    private void UpdateWaveNumberText()
    {
        // Update the wave number in the TextMeshProUGUI component
        waveNumberText.text = (currentWaveIndex + 1).ToString();
    }
}


