using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    private void OnEnable()
    {
        if (EnviromentProgress.Instance != null)
            EnviromentProgress.Instance.onEnviromentStateChanged += HandleEnvironmentStateChanged;
        else
            Debug.LogWarning("EnviromentProgress.Instance is null!");
    }

    private void OnDisable()
    {
        if (EnviromentProgress.Instance != null)
            EnviromentProgress.Instance.onEnviromentStateChanged -= HandleEnvironmentStateChanged;
    }

    private void HandleEnvironmentStateChanged()
    {
        //INSTANTIATE ANMIAL RETURN LOGIC HERE
        Debug.Log("AnimalReturn observer received state update!");
    }
}
