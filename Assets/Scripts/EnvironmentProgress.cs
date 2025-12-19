using System;
using UnityEngine;

public class EnvironmentProgress : MonoBehaviour
{
    public enum EnvironmentState
    {
        Clean,
        SlightlyPolluted,
        Polluted,
        HeavilyPolluted
    }

    public EnvironmentState currentState;

    public event Action onEnvironmentStateChanged;

    private int trashCollected = 0;

    public static EnvironmentProgress Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddTrashCollectedToTotalAmount(int amount)
    {
        trashCollected += amount;
        EvaluateEnvironmentState();
    }

    private void EvaluateEnvironmentState()
    {
        EnvironmentState newState = currentState;

        if (trashCollected >= 40)
        {
            newState = EnvironmentState.Clean;
        }

        else if (trashCollected >= 25)
        {
            newState = EnvironmentState.SlightlyPolluted;
        }

        else if (trashCollected >= 10)
        {
            newState = EnvironmentState.Polluted;
        }


        if (newState != currentState)
        {
            currentState = newState;
            onEnvironmentStateChanged();
        }
    }
}
