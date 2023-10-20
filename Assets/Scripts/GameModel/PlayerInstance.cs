using DG.Tweening;
using UnityEngine;

namespace GameModel
{
    public class PlayerInstance : RagdollInstance
    {
        [SerializeField] private InputManager input;
        [SerializeField] private CameraInstance playerCam;
        [SerializeField] private Transform camFollowTarget;

        protected override void Init()
        {
            base.Init();
            input.OnJumpInput += Jump;
        }

        protected override void Update()
        {
            base.Update();

            animController.TranslateCharacterSpeed(input.GetMovementInput().y, input.GetMovementInput().x);
            RotatePlayer();
            movementDir = transform.forward * input.GetMovementInput().y + transform.right * input.GetMovementInput().x;
            playerCam.FollowTarget(camFollowTarget);
        }

        private void RotatePlayer()
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");
            transform.RotateAround(transform.position, Vector3.up,
                rotateHorizontal); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
            camFollowTarget.RotateAround(transform.position + Vector3.up, -camFollowTarget.right,
                rotateVertical); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        }
    }
}