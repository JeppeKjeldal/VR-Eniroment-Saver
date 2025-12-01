using UnityEngine;

public class AmbienceSoundscape : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource ambientBaseLayer;
    [SerializeField] private AudioSource ambientAnimalsLayer;
    [SerializeField] private AudioSource ambientWeatherLayer;
    [SerializeField] private AudioSource ambientMusicLayer;

    [Header("Volumes per State")]
    [SerializeField] private float heavilyPollutedVolume = 0f;
    [SerializeField] private float pollutedVolume = 0.2f;
    [SerializeField] private float slightlyPollutedVolume = 0.5f;
    [SerializeField] private float cleanVolume = 1f;

    private void OnEnable()
    {
        if (EnviromentProgress.Instance != null)
        {
            EnviromentProgress.Instance.onEnviromentStateChanged += UpdateAmbienceLayers;
            Debug.Log("AmbienceSoundscape observer listening!");
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
            EnviromentProgress.Instance.onEnviromentStateChanged -= UpdateAmbienceLayers;
        }
    }

    private void Start()
    {
        ambientBaseLayer.Play();
        ambientAnimalsLayer.Play();
        ambientWeatherLayer.Play();
    }

    private void UpdateAmbienceLayers()
    {
        Debug.Log("AmbienceSoundscape observer received state update!");

        switch (EnviromentProgress.Instance.currentState)
        {
            case EnviromentProgress.EnviromentState.HeavilyPolluted:
                SetLayerVolumes(heavilyPollutedVolume);
                break;

            case EnviromentProgress.EnviromentState.Polluted:
                SetLayerVolumes(pollutedVolume);
                break;
            case EnviromentProgress.EnviromentState.SlightlyPolluted:
                SetLayerVolumes(slightlyPollutedVolume);
                break;
            case EnviromentProgress.EnviromentState.Clean:
                SetLayerVolumes(cleanVolume);
                break;
            default:
                Debug.LogWarning("Unknown EnviromentState!");
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
