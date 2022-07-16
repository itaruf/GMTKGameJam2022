using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("Timer")]

    public float startTimer = 1;
    public float gameTimer = 2;
    public float endTimer = 1;

    public float currentChrono = 0;

    // Actions
   /* public Action _onStart;
    public Action _onEnd;*/

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    public virtual IEnumerator StartGame()
    {
        float time = Time.time;
        while (Time.time - time < startTimer)
            yield return null;

        StartCoroutine(StartTimer());
    }

    public virtual bool IsCleared()
    {
        Debug.Log("Clear check");
        return false;
    }

    public IEnumerator StartTimer()
    {
        Event.current.OnStartMiniGame();
        Debug.Log("Start Game");

        float time = Time.time;
        while (Time.time - time < gameTimer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            yield return null;
        }

        Debug.Log("End Game");
        Event.current.OnEndMiniGame();
        IsCleared();
    }
}
