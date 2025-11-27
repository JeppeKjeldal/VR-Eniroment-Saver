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

    private static EnviromentProgress instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void AddTrashCollectedToTotalAmount(int amount)
    {
        trashCollected += amount;
        EvaluateEnviromentState();
    }

    private void EvaluateEnviromentState()
    {
        EnviromentState newState = currentState;

        if (trashCollected >= 20)
        {
            newState = EnviromentState.Polluted;
        }
        else if (trashCollected >= 40)
        {
            newState = EnviromentState.SlightlyPolluted;
        }
        else if (trashCollected >= 60)
        {
            newState = EnviromentState.Clean;
        }

        if (newState != currentState)
        {
            currentState = newState;
            onEnviromentStateChanged();
        }
    }
}
