using System;
using UnityEngine;

namespace Helpers
{
    public abstract class MovementHelperBase : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheckPoint;
        protected Transform targetTr;
        protected Rigidbody targetRb;
        
        public void Init(Transform tr, Rigidbody rb)
        {
            targetTr = tr;
            targetRb = rb;
        }

        protected bool IsGrounded()
        {
            return Physics.Raycast(groundCheckPoint.position, Vector3.down * 0.01f, groundLayer);
        }

        protected abstract void Move();

        private void FixedUpdate()
        {
            Move();
        }
    }
}