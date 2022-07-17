using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] GameObject _owner = null;
    [SerializeField] AnimatorController _animatorController = null;
    public Vector3 _offset = new Vector3(0, 0, 0);

    [SerializeField] float _msBoost = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        /*Event.current._onGameLost += () => { _animatorController._animator.SetBool(Animator.StringToHash("BucketFill"), false); };*/
    }

    void FixedUpdate()
    {
        if (!_owner)
            return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fireball fireBall))
        {
            _animatorController._animator.SetTrigger(Animator.StringToHash("Fill"));
            Event.current.OnCollectLava(_msBoost);
        }
    }
}
