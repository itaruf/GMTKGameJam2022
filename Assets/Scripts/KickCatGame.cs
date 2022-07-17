using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCatGame : MiniGame
{
    [SerializeField] ChatBox _text;
    private int _kickedCounter;
    [SerializeField] private int _kickGoal = 5;
    void Awake()
    {
        base.Awake();

        Event.current._onClearedMiniGame += () => { StopCoroutine((StartTimer())); };

        Event.current._onGameWon += DestroyCats;
        Event.current._onGameLost += DestroyCats;
        Event.current._onClearedMiniGame += DestroyCats;

        /*_text._textMesh.enabled = false;*/
        Event.current._onStartMiniGame += () => { _text._textMesh.enabled = true; };
        Event.current._onCatKicked += () => { _kickedCounter++; };

        StartCoroutine(StartGame());
        StartCoroutine(CountKilledCats());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public IEnumerator CountKilledCats()
    {
        while (_kickedCounter < _kickGoal)
            yield return null;

        Event.current.OnGameWon();
        StartCoroutine(OnCleared());
    }

    public override IEnumerator StartGame()
    {
        float time = Time.time;
        while (Time.time - time < startTimer)
            yield return null;

        StartCoroutine((StartTimer()));
    }
    
    public override IEnumerator OnCleared()
    {
        StartCoroutine(base.OnCleared());

        float time = Time.time;
        while (Time.time - time < endTimer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            _text._textMesh.text = "Returning in " + Mathf.Round(endTimer - currentChrono).ToString() + " ...";
            yield return null;
        }
        
        Event.current.OnClearedMiniGame();
    }

    private void OnDestroy()
    {
        Event.current._onCatKicked -= () => { _kickedCounter++; };
    }

    void DestroyCats()
    {
        var cats = FindObjectsOfType<Cat>();
        foreach (var cat in cats)
            Destroy(cat.gameObject);
    }
}
