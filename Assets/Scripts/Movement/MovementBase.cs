using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected CharacterController controller;
        [SerializeField] protected float moveSpeed = 2f;

        public void Move(Vector3 dir)
        {
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }
}