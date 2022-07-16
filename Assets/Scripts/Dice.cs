using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public AnimatorController _animatorController = null;
    public List<Sprite> sprites = new List<Sprite>();

    void Awake()
    {
        if (!_animatorController)
            TryGetComponent(out _animatorController);

    }

    void FixedUpdate()
    {
        
    }

    void SwitchSide(int result)
    {
        //_animatorController._sprite.sprite = sprites[result];
        if (!TryGetComponent(out SpriteRenderer sprite))
            return;

        sprite.sprite = sprites[result];
    }

    public IEnumerator Result()
    {
        float time = Time.time;

        /*while (_animatorController._animator.GetCurrentAnimatorStateInfo(0).IsName("DiceThrow"))
        {
            Debug.Log("yield");
            yield return null;
        }*/

        while (Time.time - time < 1f)
        {
            Debug.Log("yield");
            yield return null;
        }

        _animatorController._animator.SetBool(Animator.StringToHash("DiceThrow"), false);
        Destroy(_animatorController._animator);

        int result = Random.Range(0, 6);
        SwitchSide(result);

        Debug.Log("result");
    }
}
