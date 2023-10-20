using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float movementSmoothSpeed = 1f;
    private PlayerInputActions playerInput;
    private InputAction move;
    private InputAction run;
    private InputAction jump;

    private Vector2 dir = Vector2.zero;

    private float xSpeed = 0f;
    private float ySpeed = 0f;

    public Action OnJumpInput;

    private void Awake()
    {
        playerInput = new();
    }

    private void OnEnable()
    {
        move = playerInput.Movement.Move;
        run = playerInput.Movement.Run;
        jump = playerInput.Movement.Jump;
        
        run.Enable();
        move.Enable();
        jump.Enable();
        
        run.performed += Run;
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        run.Disable();
        jump.Disable();
        
        run.performed -= Run;
        jump.performed -= Jump;
    }

    private void Run(InputAction.CallbackContext context)
    {
        //moveSpeedMult = 2f;
    }

    public Vector2 GetMovementInput()
    {
        var inputVector = move.ReadValue<Vector2>();

        xSpeed = Mathf.Lerp(xSpeed, inputVector.x, Time.deltaTime * movementSmoothSpeed);
        ySpeed = Mathf.Lerp(ySpeed, inputVector.y, Time.deltaTime * movementSmoothSpeed);

        inputVector.x = xSpeed;
        inputVector.y = ySpeed;

        return inputVector;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        OnJumpInput?.Invoke();
    }
}