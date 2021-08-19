using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }
public class InputController : MonoBehaviour
{
    Inputs inputs;
    public MoveInputEvent moveInputEvent;

    private void Awake()
    {
        inputs = new Inputs();
    }

    private void OnEnable()
    {
        inputs.PlayerActions.Enable();
        inputs.PlayerActions.Movement.performed += OnMovePerformed;
        inputs.PlayerActions.Movement.canceled += OnMovePerformed;

    }

    private void OnDisable()
    {
        inputs.PlayerActions.Disable();
        inputs.PlayerActions.Movement.performed -= OnMovePerformed;
        inputs.PlayerActions.Movement.canceled -= OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        var moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
    }
}
