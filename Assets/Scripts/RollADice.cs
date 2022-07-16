using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollADice : MonoBehaviour
{
    void Awake()
    {
    }

    void FixedUpdate()
    {
        
    }

    void StartDice()
    {
        Event.current.OnStartRollDice();
    }
}
