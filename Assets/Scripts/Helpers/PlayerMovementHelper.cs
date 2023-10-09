using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameModel;
using UnityEngine;

namespace Helpers
{
    public class PlayerMovementHelper : MovementHelperBase
    {
        [SerializeField] private CameraInstance playerCam;
        [SerializeField] private float maxMoveSpeed = 3;
        [SerializeField] private float acceleration = 3;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float jumpsDelay = 2f;
        [SerializeField] private float runSpeeMiltiplier = 1.5f;
        [SerializeField] private Transform headTr;

        private float currXSpeed = 0f;
        private float currZSpeed = 0f;
        private bool canJump = true;

        protected override void Move()
        {
            targetTr.rotation = Quaternion.Euler(0, playerCam.transform.rotation.eulerAngles.y, 0);
            headTr.rotation = Quaternion.Euler(playerCam.transform.rotation.eulerAngles.x,
                headTr.rotation.eulerAngles.y, headTr.rotation.eulerAngles.z);

            var vInput = Input.GetAxisRaw("Vertical");
            var hInput = Input.GetAxisRaw("Horizontal");

            currZSpeed += vInput * acceleration;
            currXSpeed += hInput * acceleration;

            var speedMult = 1f;

            if (Input.GetKey(KeyCode.LeftShift))
                speedMult = runSpeeMiltiplier;

            currXSpeed = Mathf.Clamp(currXSpeed, -maxMoveSpeed * speedMult, maxMoveSpeed * speedMult);
            currZSpeed = Mathf.Clamp(currZSpeed, -maxMoveSpeed * speedMult, maxMoveSpeed * speedMult);

            if (vInput == 0)
                currZSpeed = Mathf.Lerp(currZSpeed, 0, acceleration);

            if (hInput == 0)
                currXSpeed = Mathf.Lerp(currXSpeed, 0, acceleration);

            targetRb.velocity = targetTr.forward * currZSpeed +
                                targetTr.right * currXSpeed + targetTr.up * targetRb.velocity.y;

            if (Input.GetKey(KeyCode.Space))
            {
                if (IsGrounded() && canJump)
                {
                    Debug.Log($"JUMP");
                    targetRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    JumpDelay();
                }
            }
        }

        private async UniTask JumpDelay()
        {
            canJump = false;
            await UniTask.Delay(TimeSpan.FromSeconds(jumpsDelay));
            canJump = true;
        }
    }
}