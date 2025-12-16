using UnityEngine;

public class SmogVisibility : MonoBehaviour
{
    [SerializeField] private int particlesRemovedPerState = 334;

    private ParticleSystem smogParticleSystem;

    private void Start()
    {
        smogParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        if (EnvironmentProgress.Instance != null)
            EnvironmentProgress.Instance.onEnvironmentStateChanged += ReduceAmountOfSmogOnStateChange;
    }

    private void OnDisable()
    {
        if (EnvironmentProgress.Instance != null)
            EnvironmentProgress.Instance.onEnvironmentStateChanged -= ReduceAmountOfSmogOnStateChange;
    }

    private void ReduceAmountOfSmogOnStateChange()
    {
        var main = smogParticleSystem.main;
        main.maxParticles = Mathf.Max(0, main.maxParticles - particlesRemovedPerState);

        if (main.maxParticles <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
