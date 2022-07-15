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
    [SerializeField] InputActionReference _move = null;

    // Movement
    [Header("Movement")]
    [SerializeField] float _ms = 2;
    public Vector2 Direction { get; private set; }
    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    void Awake()
    {
        if (!_rb)
            TryGetComponent(out _rb);

        if (!_animatorController)
            TryGetComponent(out _animatorController);

        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (Direction * _ms) * Time.fixedDeltaTime);
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null)
            return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                PrepareDirection(obj.ReadValue<Vector2>());
                _animatorController.FlipX(obj.ReadValue<Vector2>());
                yield return null;
            }
        }
    }

    public void MoveCanceled(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null)
            return;

        StopCoroutine(MovementTracking);
        MovementTracking = null;
        PrepareDirection(Vector2.zero);
    }
}
