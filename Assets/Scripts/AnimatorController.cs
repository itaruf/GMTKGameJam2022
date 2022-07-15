using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public SpriteRenderer _sprite = null;

    void Awake()
    {
        if (!_sprite)
            TryGetComponent(out _sprite);
    }

    public void FlipX(Vector2 direction)
    {
        switch (direction)
        {
            case Vector2 v when v.Equals(Vector2.left):
                _sprite.flipX = true;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                _sprite.flipX = false;
                break;
        }
    }
}
