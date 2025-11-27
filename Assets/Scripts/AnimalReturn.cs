using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    [SerializeField] private GameObject animalPrefab;

    private void OnEnable()
    {
        if (EnviromentProgress.Instance != null)
        {
            EnviromentProgress.Instance.onEnviromentStateChanged += HandleEnvironmentStateChanged;
            Debug.Log("AnimalReturn observer listening!");
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
            EnviromentProgress.Instance.onEnviromentStateChanged -= HandleEnvironmentStateChanged;
        }
    }

    private void HandleEnvironmentStateChanged()
    {
        Debug.Log("AnimalReturn observer received state update!");
        Instantiate(animalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
