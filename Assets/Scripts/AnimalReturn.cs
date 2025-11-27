using UnityEngine;

public class AnimalReturn : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<EnviromentProgress>().onEnviromentStateChanged += FirstAnimalsReturn;
    }

    private void OnDisable()
    {
        GetComponent<EnviromentProgress>().onEnviromentStateChanged -= FirstAnimalsReturn;
    }

    private void FirstAnimalsReturn() 
    {
        //Do Shit and instantiate
    }
}
