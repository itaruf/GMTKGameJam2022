using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event : MonoBehaviour
{
    public static Event current;

    // Actions
    public event Action _onStartMiniGame;
    public event Action _onEndMiniGame;

    public event Action _onRollDiceStarted;
    public event Action _onRollDiceEnded;

    public event Action<int> _onDiceResult;

    private void Awake()
    {
        current = this;
       /* if (Instance && Instance != this)
            Destroy(this);

        else
            Instance = this;*/
    }

    public void OnStartMiniGame()
    {
        _onStartMiniGame?.Invoke();
    }

    public void OnEndMiniGame()
    {
        _onEndMiniGame?.Invoke();
    }

    public void OnStartRollDice()
    {
        _onRollDiceStarted?.Invoke();
    }

    public void OnEndRollDice()
    {
        _onRollDiceEnded?.Invoke();
    }
}
