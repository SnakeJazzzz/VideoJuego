using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public TextMeshProUGUI waveNumberText;
    public WaveList waveList;
    private int currentWaveIndex = 0;

    private void Start()
    {
        waveNumberText = GameObject.FindWithTag("WaveNumber").GetComponent<TextMeshProUGUI>();
        if (waveNumberText == null)
        {
            Debug.LogError("WaveCounter: Failed to find the Wave Number TextMeshProUGUI component in the scene.");
            return;
        }
        UpdateWaveNumberText();
    }

    public void OnWaveCompleted()
    {
        if (waveNumberText == null)
        {
            waveNumberText = GameObject.FindWithTag("WaveNumber").    GetComponent<TextMeshProUGUI>();
            if (waveNumberText == null)
            {
                Debug.LogError("WaveCounter: Failed to find the Wave Number     TextMeshProUGUI component after completing a wave.");
                return;
            }
        }
        currentWaveIndex++;
        UpdateWaveNumberText();
    }

    private void UpdateWaveNumberText()
    {
        waveNumberText.text = (currentWaveIndex + 1).ToString();
    }
}
