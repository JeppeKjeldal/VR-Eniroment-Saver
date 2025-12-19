using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    //[SerializeField] private List<GameObject> landAnimals;
    //[SerializeField] private List<Transform> landSpawnPoints;
    [SerializeField] private List<GameObject> seaAnimals;
    [SerializeField] private List<Transform> seaSpawnPoints;

    private void OnEnable()
    {
        if (EnvironmentProgress.Instance != null)
        {
            EnvironmentProgress.Instance.onEnvironmentStateChanged += HandleEnvironmentStateChanged;
        }
        else
        {
            Debug.LogWarning("EnvironmentProgress.Instance is null!");
        }
    }

    private void OnDisable()
    {
        if (EnvironmentProgress.Instance != null)
        {
            EnvironmentProgress.Instance.onEnvironmentStateChanged -= HandleEnvironmentStateChanged;
        }
    }

    private void HandleEnvironmentStateChanged()
    {
        for (int i = 0; i < 2; i++)
        {
            //SpawnRandomLandAnimal();
            SpawnRandomSeaAnimal();
        }
    }

    //private void SpawnRandomLandAnimal()
    //{
    //    int animalIndex = Random.Range(0, landAnimals.Count);
    //    int spawnPointIndex = Random.Range(0, landSpawnPoints.Count);

    //    Instantiate(landAnimals[animalIndex], landSpawnPoints[spawnPointIndex].position, Quaternion.identity);

    //    landSpawnPoints.RemoveAt(spawnPointIndex);
    //}

    private void SpawnRandomSeaAnimal()
    {
        int animalIndex = Random.Range(0, seaAnimals.Count);
        int spawnPointIndex = Random.Range(0, seaSpawnPoints.Count);

        Instantiate(seaAnimals[animalIndex], seaSpawnPoints[spawnPointIndex].position, Quaternion.identity);

        seaSpawnPoints.RemoveAt(spawnPointIndex);
    }
}
