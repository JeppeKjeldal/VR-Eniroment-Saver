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
        if (EnviromentProgress.Instance != null)
            EnviromentProgress.Instance.onEnviromentStateChanged += ReduceAmountOfSmogOnStateChange;
    }

    private void OnDisable()
    {
        if (EnviromentProgress.Instance != null)
            EnviromentProgress.Instance.onEnviromentStateChanged -= ReduceAmountOfSmogOnStateChange;
    }

    private void ReduceAmountOfSmogOnStateChange()
    {
        var main = smogParticleSystem.main;
        main.maxParticles = Mathf.Max(0, main.maxParticles - particlesRemovedPerState);

        if (main.maxParticles < 0)
        {
            main.maxParticles = 0;
        }
    }
}
