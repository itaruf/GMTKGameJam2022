using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] AnimatorController _animatorController = null;
    public SpriteRenderer _sprite = null;
    public ChatBox _text = null;

    public bool _isAnswer = false;
    public bool _inIn = false;

    void Awake()
    {
        if (!_sprite)
            TryGetComponent(out _sprite);
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        _inIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        _inIn = false;
    }
}
