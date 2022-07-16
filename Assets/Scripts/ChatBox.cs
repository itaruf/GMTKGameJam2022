using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    public SpriteRenderer _sprite = null;
    public TextMeshPro _textMesh = null;

    void Awake()
    {
        if (!_sprite)
            TryGetComponent(out _sprite);

        if (!_textMesh)
            TryGetComponent(out _textMesh);
    }

    public void SetText(string text)
    {
        _textMesh.text = text;
    }
}
