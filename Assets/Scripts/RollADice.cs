using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollADice : MonoBehaviour
{
    [SerializeField] ChatBox _message = null;

    void Awake()
    {
        StartDice();
    }

    void FixedUpdate()
    {
        
    }

    public void StartDice()
    {
        if (!Event.current)
            return;
        
        Event.current.OnStartRollDice();
    }
}
