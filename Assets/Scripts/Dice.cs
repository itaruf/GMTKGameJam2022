using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public AnimatorController _animatorController = null;
    public List<Sprite> sprites = new List<Sprite>();

    [SerializeField] int numberOfFaces = 6;
    [SerializeField] Vector2 _diceForce = new Vector2(100, 300);
    [SerializeField] Rigidbody2D _rb = null;

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
        if (!TryGetComponent(out SpriteRenderer sprite))
            return;

        Debug.Log("result : " + (result));
        sprite.sprite = sprites[result];

    } 

    public IEnumerator Result()
    {
        Event.current.OnStartRollDice();

        _animatorController._animator.SetBool(Animator.StringToHash("DiceThrow"), true);

        _rb.AddForce(_diceForce);

        float time = Time.time;
        while ((Time.time - time) < 1f)
            yield return null;

        _animatorController._animator.SetBool(Animator.StringToHash("DiceThrow"), false);
        Destroy(_animatorController._animator);

        /*Quaternion start = Quaternion.Euler(transform.rotation.eulerAngles);
        Quaternion end = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        time = Time.time;
        while ((Time.time - time) < 1f)
        {
            transform.rotation = Quaternion.Lerp(start, end, (Time.time - time));
            yield return null;
        }*/

        int result = Random.Range(0, numberOfFaces);
        SwitchSide(result);

        Event.current.OnEndRollDice();
        Event.current.OnDiceResult(result + 1);
    }
}
