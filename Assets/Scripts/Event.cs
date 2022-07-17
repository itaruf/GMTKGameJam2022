using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public float timer = 2;

    [Header("Chrono")]
    float currentChrono = 0;
    [SerializeField] ChatBox _chronoText = null;

    public static Event current;

    // Actions
    public event Action _onStartMiniGame;
    public event Action _onEndMiniGame;
    public event Action _onClearedMiniGame;
    public event Action _onHalfWayMinGame;
    public event Action _onCrucialTimeMinGame;

    public event Action _onRollDiceStarted;
    public event Action _onRollDiceEnded;

    public event Action _onKick;
    public event Action _onCatKicked;
    public event Action<int> _onDiceResult;

    public event Action _onGameLost;
    public event Action _onGameWon;

    public event Action<float> _onCollectLava;

    private void Awake()
    {
        current = this;

        _onDiceResult += SelectMiniGame;
        _onRollDiceEnded += () => { _chronoText._textMesh.gameObject.SetActive(true); };
        _onClearedMiniGame += () => { SceneManager.LoadScene("DiceScene"); };
    }

    public void OnStartMiniGame()
    {
        _onStartMiniGame?.Invoke();
    }

    public void OnEndMiniGame()
    {
        _onEndMiniGame?.Invoke();
    }

    public void HalfwayMiniGame()
    {
        _onHalfWayMinGame?.Invoke();   
    }
    
    public void CrucialTimeMiniGame()
    {
        _onCrucialTimeMinGame?.Invoke();
    }

    public void OnStartRollDice()
    {
        _onRollDiceStarted?.Invoke();
    }

    public void OnEndRollDice()
    {
        _onRollDiceEnded?.Invoke();
    }

    public void Kick()
    {
        _onKick?.Invoke();
    }

    public void CatKicked()
    {
        _onCatKicked?.Invoke();
    }
    public void OnDiceResult(int result)
    {
        _onDiceResult?.Invoke(result);
    }

    public void SelectMiniGame(int result)
    {
        Debug.Log(result);
        StartCoroutine(SelectMiniGameCoroutine(result));
    }

    public void OnClearedMiniGame()
    {
        _onClearedMiniGame?.Invoke();
    }

    public void OnGameLost()
    {
        _onGameLost?.Invoke();
    }
    
    public void OnGameWon()
    {
        _onGameWon?.Invoke();
    }
    
    public void OnCollectLava(float value)
    {
        _onCollectLava?.Invoke(value);
    }

    IEnumerator SelectMiniGameCoroutine(int result)
    {
        float time = Time.time;
        while (Time.time - time < timer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            _chronoText._textMesh.text = "Starting game in " + Mathf.Round(timer - currentChrono).ToString() + " ...";
            yield return null;
        }

        switch (result)
        {
            case 1:
                SceneManager.LoadScene("CalculScene");
                break;
            case 2:
                SceneManager.LoadScene("FireBallScene");
                break;
            case 3:
                SceneManager.LoadScene("IceJumpScene");
                break;
            case 4:
                SceneManager.LoadScene("LaserScene");
                break;
            case 5:
                SceneManager.LoadScene("KickCat");
                break;
            case 6:
                SceneManager.LoadScene("FireBallScene");
                break;
        }

    }
}
