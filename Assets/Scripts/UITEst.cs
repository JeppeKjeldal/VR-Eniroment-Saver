using UnityEngine;
using TMPro;

public class UITEst : MonoBehaviour
{
    public TMP_Text sampleText;
    private int cointCount = 0;

    public void UpdateCoinCount()
    {
        cointCount++;
        sampleText.text = "Coins: " + cointCount.ToString();
    }

    private void Update()
    {
        UpdateCoinCount();
    }
}
