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

        if (trashCollected >= 1)
        {
            newState = EnviromentState.Polluted;
            Debug.Log(currentState);
        }
        else if (trashCollected >= 2)
        {
            newState = EnviromentState.SlightlyPolluted;
            Debug.Log(currentState);
        }
        else if (trashCollected >= 3)
        {
            newState = EnviromentState.Clean;
            Debug.Log(currentState);
        }

        if (newState != currentState)
        {
            currentState = newState;
            onEnviromentStateChanged();
        }
    }
}
