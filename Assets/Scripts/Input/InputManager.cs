using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInput;
    private InputAction move;
    private InputAction run;

    private float moveSpeed = 5f;
    private float moveSpeedMult = 1f;

    private Vector2 dir = Vector2.zero;

    private void Awake()
    {
        playerInput = new();
    }

    private void OnEnable()
    {
        move = playerInput.Movement.Move;
        run = playerInput.Movement.Run;
        run.Enable();
        move.Enable();
        run.performed += Run;
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Run(InputAction.CallbackContext context)
    {
        moveSpeedMult = 2f;
    }

    public Vector2 GetMovementInput() => move != null && move.enabled ? move.ReadValue<Vector2>() : Vector2.zero;
}