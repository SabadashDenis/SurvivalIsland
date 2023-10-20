using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected CharacterController controller;
        [SerializeField] protected float moveSpeed = 2f;
        [SerializeField] protected float jumpForce = 5f;

        protected Vector3 gravity = Vector3.down;
        protected Vector3 jump = Vector3.zero;

        protected bool isJumping = false;

        public void Move(Vector3 dir)
        {
            CalculateGravity();
            CalculateJump();
            controller.Move((gravity + jump + dir * moveSpeed) * Time.deltaTime);
        }

        private void CalculateGravity()
        {
            if (controller.isGrounded)
            {
                gravity = Vector3.down;
                return;
            }

            gravity *=  1 + Time.deltaTime;
        }

        private void CalculateJump()
        {
            if (controller.isGrounded && !isJumping)
            {
                jump = Vector3.zero;
                return;
            }

            jump *= 1 - Time.deltaTime;
            isJumping = false;
        }

        public void Jump()
        {
            if(!controller.isGrounded)
                return;
            
            isJumping = true;
            jump = Vector3.up * jumpForce;
        }
    }
}