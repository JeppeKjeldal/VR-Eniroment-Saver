using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealing : MonoBehaviour
{
    [SerializeField] private List<GameObject> plantsToGrow;

    private int plantsToGrowPerState = 2;

    private float startScale = 0.1f;
    private float targetScale = 1f;
    private float growDuration = 10f;

    [SerializeField] private AudioClip growClip;

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
        Debug.Log("PlantHealing observer received state update!");

        if (plantsToGrow.Count > 0)
        {
            for (int i = 0; i < plantsToGrowPerState; i++)
            {
                int randomIndex = Random.Range(0, plantsToGrow.Count);
                GameObject plantToGrow = plantsToGrow[randomIndex];
                plantsToGrow.RemoveAt(randomIndex);

                plantToGrow.SetActive(true);

                StartCoroutine(GrowthCoroutine(plantToGrow));
            }
        }
    }

    IEnumerator GrowthCoroutine(GameObject plant)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = Vector3.one * startScale;
        Vector3 finalScale = Vector3.one * targetScale;

        plant.transform.localScale = initialScale;

        AudioSource.PlayClipAtPoint(growClip, plant.transform.position);

        while (elapsedTime < growDuration)
        {
            plant.transform.localScale = Vector3.Lerp(initialScale, finalScale, (elapsedTime / growDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        plant.transform.localScale = finalScale;
    }
}
