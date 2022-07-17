using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("Timer")]
    public float startTimer = 1;
    public float gameTimer = 10;
    public float endTimer = 3;

    [Header("Chrono")]
    protected float currentChrono = 0;
    [SerializeField] ChatBox _chronoText = null;
    private bool _halfwayPointReached = false;

    IEnumerator StartTimerEnumerator = null;

    bool _win = false;

    public void Awake()
    {
        _chronoText._textMesh.text = gameTimer.ToString();
        _chronoText._textMesh.enabled = false;

        /*Event.current._onStartMiniGame += () => { _chronoText._textMesh.enabled = true; };*/
        if (!Event.current)
            Debug.Log("is null");

        StartTimerEnumerator = StartTimer();

        Event.current._onStartMiniGame += () => { _chronoText._textMesh.enabled = true; };
        Event.current._onGameOutroStart += () => { _chronoText._textMesh.gameObject.SetActive(false); };

        Event.current._onGameLost += StopGame;
        /*Event.current._onGameLost += () => { StopCoroutine(StartTimerEnumerator); };*/

        /*Event.current._onGameWin += StopGame;
        Event.current._onGameWin += () => { StopCoroutine(StartTimerEnumerator); };*/
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

    public virtual IEnumerator GameOutro()
    {
        Event.current.OnGameOutroStart();
        _chronoText._textMesh.gameObject.SetActive(false);

       /* if (_win)
            Event.current.OnGameWin();
        else
            Event.current.OnGameLost();*/

        yield return null;
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

            if (!_halfwayPointReached)
                CheckIfHalfWayPointReached(currentChrono);

            yield return null;
        }

        _win = true;
        StopGame();
    }

    public void CheckIfHalfWayPointReached(float currentChrono)
    {
        if (currentChrono >= gameTimer / 2)
        {
            Event.current.HalfwayMiniGame();
            _halfwayPointReached = true;
        }
    }
    public virtual void StopGame()
    {
        Debug.Log("Stop Game");

        StopCoroutine(StartTimerEnumerator);

        Event.current.OnEndMiniGame();
        StartCoroutine(GameOutro());
    }
}
