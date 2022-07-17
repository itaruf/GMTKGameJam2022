using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGame : MiniGame
{
    [SerializeField] ChatBox _text;

    void Awake()
    {
        base.Awake();

        Event.current._onStartMiniGame += () => { _text._textMesh.enabled = true; };
        Event.current._onGameLost += DestroyLasers;

        StartCoroutine(StartGame());
    }

    void Update()
    {

    }

    public override IEnumerator StartGame()
    {
        float time = Time.time;
        while (Time.time - time < startTimer)
            yield return null;

        StartCoroutine(StartTimer());
    }

    public override IEnumerator OnCleared()
    {
        StartCoroutine(base.OnCleared());
        DestroyLasers();
        Event.current.OnGameWon();

        float time = Time.time;
        while (Time.time - time < endTimer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            _text._textMesh.text = "Returning in " + Mathf.Round(endTimer - currentChrono).ToString() + " ...";
            yield return null;
        }

        Event.current.OnClearedMiniGame();
    }

    void DestroyLasers()
    {
        var lasers = FindObjectsOfType<Laser>();
        foreach (var laser in lasers)
            laser.DestroyLaser();
    }
}
