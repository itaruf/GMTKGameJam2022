using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollADice : MonoBehaviour
{
    [SerializeField] ChatBox _message = null;
    [SerializeField] Dice _dice = null;

    public Action<IEnumerator> _onDice;

    void Awake()
    {
        StartCoroutine(StartDice());

        Event.current._onDiceResult += (param) => { _message._textMesh.text = "You rolled a " + (param +  1) + " !"; };
    }

    void FixedUpdate()
    {
        
    }

    public IEnumerator StartDice()
    {
        if (!Event.current)
            yield return null;
    }
}
