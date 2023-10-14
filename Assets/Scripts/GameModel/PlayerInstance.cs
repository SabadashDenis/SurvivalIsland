using UnityEngine;

namespace GameModel
{
    public class PlayerInstance : RagdollInstance
    {
        [SerializeField] private InputManager input;

        private void Update()
        {
            movement.Move(transform.forward * input.GetMovementInput().y + transform.right * input.GetMovementInput().x);
        }
    }
}