using UnityEngine;

public class AmbienceSoundscape : MonoBehaviour
{
    [SerializeField] private AudioSource ambientBaseLayer;
    [SerializeField] private AudioSource ambientAnimalsLayer;
    [SerializeField] private AudioSource ambientWeatherLayer;

    [SerializeField] private float heavilyPollutedVolume = 0f;
    [SerializeField] private float pollutedVolume = 0.2f;
    [SerializeField] private float slightlyPollutedVolume = 0.5f;
    [SerializeField] private float cleanVolume = 1f;

    private void Start()
    {
        UpdateAmbienceLayers();

        ambientBaseLayer.Play();
        ambientAnimalsLayer.Play();
        ambientWeatherLayer.Play();
    }

    private void OnEnable()
    {
        if (EnvironmentProgress.Instance != null)
        {
            EnvironmentProgress.Instance.onEnvironmentStateChanged += UpdateAmbienceLayers;
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
            EnvironmentProgress.Instance.onEnvironmentStateChanged -= UpdateAmbienceLayers;
        }
    }

    private void UpdateAmbienceLayers()
    {
        switch (EnvironmentProgress.Instance.currentState)
        {
            case EnvironmentProgress.EnvironmentState.HeavilyPolluted:
                SetLayerVolumes(heavilyPollutedVolume);
                break;

            case EnvironmentProgress.EnvironmentState.Polluted:
                SetLayerVolumes(pollutedVolume);
                break;

            case EnvironmentProgress.EnvironmentState.SlightlyPolluted:
                SetLayerVolumes(slightlyPollutedVolume);
                break;

            case EnvironmentProgress.EnvironmentState.Clean:
                SetLayerVolumes(cleanVolume);
                break;

            default:
                Debug.LogWarning("Unknown EnvironmentState!");
                break;
        }
    }

    private void SetLayerVolumes(float volume)
    {
        ambientBaseLayer.volume = volume;
        ambientAnimalsLayer.volume = volume;
        ambientWeatherLayer.volume = volume;
    }
}
