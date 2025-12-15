using System;
using UnityEngine;

public class EnviromentProgress : MonoBehaviour
{
    public enum EnviromentState
    {
        Clean,
        SlightlyPolluted,
        Polluted,
        HeavilyPolluted
    }

    public EnviromentState currentState;

    public event Action onEnviromentStateChanged;

    private int trashCollected = 0;

    public static EnviromentProgress Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddTrashCollectedToTotalAmount(int amount)
    {
        trashCollected += amount;
        EvaluateEnviromentState();
    }

    private void EvaluateEnviromentState()
    {
        EnviromentState newState = currentState;

        if (trashCollected >= 40)
        {
            newState = EnviromentState.Clean;
            Debug.Log(currentState);
            Debug.Log(trashCollected);
        }

        else if (trashCollected >= 25)
        {
            newState = EnviromentState.SlightlyPolluted;
            Debug.Log(currentState);
            Debug.Log(trashCollected);
        }

        else if (trashCollected >= 10)
        {
            newState = EnviromentState.Polluted;
            Debug.Log(currentState);
            Debug.Log(trashCollected);
        }


        if (newState != currentState)
        {
            currentState = newState;
            onEnviromentStateChanged();
        }
    }
}
