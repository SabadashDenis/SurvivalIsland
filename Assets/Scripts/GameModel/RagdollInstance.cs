using System.Collections.Generic;
using UnityEngine;

namespace GameModel
{
    public class RagdollInstance : DamagerInstance
    {
        [SerializeField] private List<Rigidbody> ragdollBase = new();
        protected override void Activate(bool condition)
        {
            foreach (var ragdollPart in ragdollBase)
            {
                ragdollPart.isKinematic = condition;
            }
        }
    }
}