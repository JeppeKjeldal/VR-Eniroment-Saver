using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    [SerializeField] private GameObject[] animals;
    [SerializeField] private Transform[] spawnPoints;

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

        for (int i = 0; i < 2; i++)
        {
            SpawnRandomAnimal();
        }
    }

    private void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animals.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(animals[index], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
