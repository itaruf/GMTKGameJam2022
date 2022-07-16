using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CalculGame : MiniGame
{
    public List<Area> _areas = new List<Area>();
    int _result = 0;
    Area _chosenArea = null;

    [Header("Calcul values")]
    [SerializeField] int numberOfValues = 4;
    [SerializeField] int _minValue = 2;
    [SerializeField] int _maxValue = 2;

    [Header("Other answers differences")]
    [SerializeField] int _minOffValue = 10;
    [SerializeField] int _maxOffValue = 10;

    [SerializeField] ChatBox _text;
    int count = 0;

    void Awake()
    {
        base.Awake();

        _text._textMesh.enabled = false;
        Event.current._onStartMiniGame += () => { _text._textMesh.enabled = true; };

        List<int> numbers = new List<int>(numberOfValues);

        for (int i = 0; i < numberOfValues; ++i)
            numbers.Add(Random.Range(_minValue, _maxValue));

        _result = numbers[0];

        ProcessQuestion(numbers);

        int chosen = Random.Range(0, _areas.Count);

        if (_areas.Count <= 0)
            return;

        foreach (Area area in _areas)
        {
            area._text._textMesh.enabled = false;
            Event.current._onStartMiniGame += () => { area._text._textMesh.enabled = true; };

            if (area == _areas[chosen])
            {
                _chosenArea = _areas[chosen];
                _chosenArea._isAnswer = true;
                Debug.Log($"Correct answer : {_result}");
                _chosenArea._text.SetText(_result.ToString());
            }

            else
            {
                count++;
                int r = Random.Range(_result - _minOffValue, _result + _maxOffValue + 1);

                if (r == _result)
                    r -= count;

                area._text.SetText(r.ToString());
            }
        }

        StartCoroutine(StartGame());
    }

    void FixedUpdate()
    {
        
    }

    public override IEnumerator StartGame()
    {
        float time = Time.time;
        while (Time.time - time < startTimer)
            yield return null;

        StartCoroutine(StartTimer());
    }

    public override bool IsCleared()
    {
        if (_chosenArea._inIn)
        {
            Debug.Log("Correct !");
            return true;
        }

        else
            Debug.Log("Wrong !");

        return false;
    }

    void ProcessQuestion(List<int> numbers)
    {
        _text._textMesh.text += "\n" + numbers[0];

        for (int i = 1; i < numbers.Count; ++i)
        {
            _text._textMesh.text += " + " + numbers[i];
            _result += numbers[i];
        }

        _text._textMesh.text += " ?";
    }
}
