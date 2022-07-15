using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("Timer")]
    public float timer = 2;
    public float currentChrono = 0;

    // Actions
    public Action _onStart;
    public Action _onEnd;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator StartTimer()
    {
        _onStart?.Invoke();

        float time = Time.time;
        while (Time.time - time < timer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            yield return null;
        }

        _onEnd?.Invoke();
    }
}
