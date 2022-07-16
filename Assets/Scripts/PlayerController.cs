using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] AnimatorController _animatorController = null;
    [SerializeField] Rigidbody2D _rb = null;

    // Inputs
    [Header("Input")]
    [SerializeField] PlayerInput _inputAction = null;
    [SerializeField] InputActionReference _move = null;
    [SerializeField] InputActionReference _jump = null;
    [SerializeField] InputActionReference _rolldice = null;

    // Movement
    [Header("Movement")]
    [SerializeField] float _ms = 2;
    [SerializeField] float _jumpForce = 5;
    Vector2 moveValue = new Vector2(0, 0);

    private bool _isJumping = false;
    private bool _canRollDice = false;

    public Vector2 Direction { get; private set; }
    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    void Awake()
    {
        Event.current._onRollDiceStarted += () => { _canRollDice = true; };
        Event.current._onRollDiceEnded += () => { _canRollDice = false; };

        if (!_rb)
            TryGetComponent(out _rb);

        if (!_animatorController)
            TryGetComponent(out _animatorController);

        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;

        _jump.action.performed += JumpInput;
        _jump.action.canceled += JumpCanceled;

        /*_rolldice.action.started += RollDiceInput;*/
    }

    private void RollDiceInput(InputAction.CallbackContext obj)
    {
        _animatorController._animator.SetTrigger(Animator.StringToHash("RollDice"));
    }

    private void JumpCanceled(InputAction.CallbackContext obj)
    {
        /*jumpForce = 0;*/
    }

    private void JumpInput(InputAction.CallbackContext obj)

    {   if (_isJumping)
            return;

        _isJumping = true;
        _rb.AddForce((Vector2.up * _jumpForce), ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

        _jump.action.performed -= JumpInput;
        _jump.action.performed -= MoveCanceled;

        _rolldice.action.started -= RollDiceInput;

    }

    void FixedUpdate()
    {
        /*if (MovementTracking != null)
            _rb.MovePosition(_rb.position + (Direction * _ms) * Time.fixedDeltaTime);*/

        Move();
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        /*   if (MovementTracking != null)
               return;

           MovementTracking = StartCoroutine(MovementTrackingRoutine());
           IEnumerator MovementTrackingRoutine()
           {
               while (true)
               {
                   PrepareDirection(obj.ReadValue<Vector2>());
                   _animatorController.FlipX(obj.ReadValue<Vector2>());
                   yield return null;

                   _rb.MovePosition(_rb.position + (Direction * _ms) * Time.fixedDeltaTime);
               }
           }*/

        moveValue = obj.ReadValue<Vector2>();
        _animatorController.FlipX(obj.ReadValue<Vector2>());
        _animatorController._animator.SetBool(Animator.StringToHash("IsMoving"), true);
    }

    private void Move()
    {
        transform.Translate(moveValue * Time.fixedDeltaTime * _ms);
    }

    public void MoveCanceled(InputAction.CallbackContext obj)
    {
        moveValue = new Vector2(0, 0);
        _animatorController._animator.SetBool(Animator.StringToHash("IsMoving"), false);

        if (MovementTracking == null)
            return;

        StopCoroutine(MovementTracking);
        MovementTracking = null;
        PrepareDirection(Vector2.zero);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Foreground"))
            _isJumping = false;
    }

}
