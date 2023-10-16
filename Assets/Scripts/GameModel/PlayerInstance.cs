using UnityEngine;

namespace GameModel
{
    public class PlayerInstance : RagdollInstance
    {
        [SerializeField] private InputManager input;

        protected override void Update()
        {
            base.Update();
            movementDir = transform.forward * input.GetMovementInput().y + transform.right * input.GetMovementInput().x;
            //Debug.Log($"Movement Dir: {movementDir}");
        }
    }
}