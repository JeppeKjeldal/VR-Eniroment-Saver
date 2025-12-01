using UnityEngine;

public class PlantHealing : MonoBehaviour
{
    private GameObject[] plantsToGrow;
    private GameObject[] plantsAlreadyGrown;

    private void OnEnable()
    {
        if (EnviromentProgress.Instance != null)
        {
            EnviromentProgress.Instance.onEnviromentStateChanged += GrowPlants;
            Debug.Log("PlantHealing observer listening!");
        }
        else
        {
            Debug.LogWarning("EnviromentProgress.Instance is null!");
        }
    }

    private void OnDisable()
    {
        if (EnviromentProgress.Instance != null)
        {
            EnviromentProgress.Instance.onEnviromentStateChanged -= GrowPlants;
        }
    }

    private void GrowPlants()
    {

    }
}
