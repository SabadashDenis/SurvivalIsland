using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected CharacterController controller;
        [SerializeField] protected float moveSpeed = 2f;
        private Vector3 moveDirection = Vector3.zero;

        public Vector2 GetMoveDirection => moveDirection;

        protected void Update()
        {
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        
        public void Move(Vector3 dir)
        {
            moveDirection = dir;
        }
    }
}