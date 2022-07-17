using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Image _dialogueBG;
    [SerializeField] private List<string> _dialogue;
    [SerializeField] private float _dialogueSpeed = 5.0f;
    private Queue<string> _dialogueQueue;
    
    private bool _dialogueIsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        _dialogueText.enabled = true;
        _dialogueBG.enabled = true;
        _dialogueQueue = new Queue<string>();
        foreach (string line in _dialogue)
        {
            _dialogueQueue.Enqueue(line);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!_dialogueIsPlaying)
        {
            StartCoroutine(DialogueCoroutine());
        }
        
    }

    void SetText(string text)
    {
        _dialogueText.text = text;
    }

    IEnumerator DialogueCoroutine()
    {
        _dialogueIsPlaying = true;
        while (_dialogueQueue.Count >0)
        {
            SetText(_dialogueQueue.Dequeue());
            yield return new WaitForSeconds(_dialogueSpeed);
        }
        SceneManager.LoadScene("DiceScene");
        
    }
    
}
