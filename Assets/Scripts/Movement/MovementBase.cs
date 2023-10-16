using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected CharacterController controller;
        [SerializeField] protected float moveSpeed = 2f;

        protected Vector3 gravity = Vector3.down * 9.8f;

        public void Move(Vector3 dir)
        {
            controller.Move((gravity + dir * moveSpeed) * Time.deltaTime);
        }
    }
}