using UnityEngine;

namespace GameModel
{
    public class RagdollInstance : DamagerInstance
    {
        [SerializeField] protected AnimationController animController;

        protected override void Update()
        {
            base.Update();
            animController.TranslateCharacterSpeed(movementDir);
        }
    }
}