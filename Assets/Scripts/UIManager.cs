using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startText;
    [SerializeField] private float _flickeringDuration = 0.5f;
    [SerializeField] private Image _timerBar;
    [SerializeField] private float _chrono;
    private float _timeLeft;
    private float _maxTime;
    private bool _allowFlickering = true;
    private bool _gameHasStarted = true;
    private MiniGame _minigame;
    // Start is called before the first frame update
    void Start()
    {
        Event.current._onStartMiniGame += GameHasStarted;

        if (_gameHasStarted)
        {
            _minigame = GameObject.Find("Game_Manager").GetComponent<MiniGameManager>().GetCurrentGame();

            _maxTime = _minigame.gameTimer;
            _timeLeft = _maxTime;
        }

        IEnumerator timer = Timer();

        Event.current._onStartMiniGame += () => { StartCoroutine(timer); };
        Event.current._onEndMiniGame += () => { StopCoroutine(timer); };

        /*Event.current._onGameLost += () => { StopCoroutine(timer); };
        Event.current._onGameLost += () => { if (_startText) _startText.text = "You loose !"; };

        Event.current._onGameWin += () => { StopCoroutine(timer); };
        Event.current._onGameWin += () => { if (_startText) _startText.text = "You win !"; };*/
    }

    private void GameHasStarted()
    {
        _gameHasStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_allowFlickering && (SceneManager.GetActiveScene().name == "StartMenu"))
            StartCoroutine(DisableStartTextCoroutine());
    }

    IEnumerator Timer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            _timerBar.fillAmount = _timeLeft / _maxTime;
            yield return null;
        }
    }

    IEnumerator DisableStartTextCoroutine()
    {
        _allowFlickering = false;
        yield return new WaitForSeconds(_flickeringDuration);
        _startText.enabled = !_startText.enabled;
        _allowFlickering = true;
    }

    public void StartGame(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            SceneManager.LoadScene("IntroScene");
        }
    }

    private void OnDestroy()
    {
        Event.current._onStartMiniGame -= GameHasStarted;
    }
}
