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


    [Header("Chrono")]
    public float currentChrono = 0;
    [SerializeField] ChatBox _chronoText = null;

    public void Awake()
    {
        /*_chronoText._textMesh.enabled = false;*/
        _chronoText._textMesh.text = gameTimer.ToString();
        /*Event.current._onStartMiniGame += () => { _chronoText._textMesh.enabled = true; };*/
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
            _chronoText._textMesh.text = Mathf.Round(gameTimer - currentChrono).ToString();
            yield return null;
        }

        Debug.Log("End Game");
        Event.current.OnEndMiniGame();
        IsCleared();
    }
}
