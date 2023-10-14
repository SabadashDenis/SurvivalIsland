using Movement;
using UnityEngine;

namespace GameModel
{
    public class MovableInstance : HealthInstance
    {
        [SerializeField] protected MovementBase movement;
        
    }
}