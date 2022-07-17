using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGame : MiniGame
{

    [SerializeField] ChatBox _text;
    void Awake()
    {
        base.Awake();
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
        // if (_chosenArea._inIn)
        //     Debug.Log("Correct !");
        //
        // else
        //     Debug.Log("Wrong !");
    
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
}
