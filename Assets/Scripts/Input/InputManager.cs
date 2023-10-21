using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float movementSmoothSpeed = 1f;
    private PlayerInputActions playerInput;
    private InputAction move;
    private InputAction jump;

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
        jump = playerInput.Movement.Jump;
        
        move.Enable();
        jump.Enable();
        
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        
        jump.performed -= Jump;
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