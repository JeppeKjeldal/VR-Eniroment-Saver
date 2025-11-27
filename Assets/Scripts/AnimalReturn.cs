using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    private void Start()
    {
        if (EnviromentProgress.Instance != null)
            EnviromentProgress.Instance.onEnviromentStateChanged += FirstAnimalsReturn;
        else
            Debug.LogWarning("EnviromentProgress.Instance is null!");
    }

    private void FirstAnimalsReturn()
    {
        Debug.Log("First animals are returning to the cleaned environment!");
    }
}
