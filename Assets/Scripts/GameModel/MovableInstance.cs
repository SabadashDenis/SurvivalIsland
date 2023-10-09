using Helpers;
using UnityEngine;

namespace GameModel
{
    public class MovableInstance : HealthInstance
    {
        [SerializeField] private MovementHelperBase movementHelper;
        [SerializeField] private Rigidbody rigidbody;

        protected override void Init()
        {
            base.Init();
            movementHelper.Init(transform, rigidbody);
        }
    }
}