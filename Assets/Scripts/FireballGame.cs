using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGame : MiniGame
{
    [SerializeField] ChatBox _text;

    void Awake()
    {
        base.Awake();

        /*_text._textMesh.enabled = false;*/
        Event.current._onStartMiniGame += () => { _text._textMesh.enabled = true; };

        StartCoroutine(StartGame());
    }

    // Update is called once per frame
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
}
