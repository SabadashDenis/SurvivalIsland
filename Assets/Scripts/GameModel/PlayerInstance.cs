using DG.Tweening;
using UnityEngine;

namespace GameModel
{
    public class PlayerInstance : RagdollInstance
    {
        [SerializeField] private InputManager input;

        protected override void Init()
        {
            base.Init();
            input.OnJumpInput += Jump;
        }

        protected override void Update()
        {
            base.Update();
            
            movementDir = transform.forward * input.GetMovementInput().y + transform.right * input.GetMovementInput().x;
            
        }
    }
}