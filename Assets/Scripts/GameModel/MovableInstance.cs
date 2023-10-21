using DG.Tweening;
using Movement;
using UnityEngine;

namespace GameModel
{
    public class MovableInstance : HealthInstance
    {
        [SerializeField] protected MovementBase movement;
        protected Vector3 movementDir = Vector3.zero;


        protected override void Update()
        {
            base.Update();
            movement.Move(movementDir);
        }

        protected virtual void Jump()
        {
            movement.Jump();
        }
    }
}