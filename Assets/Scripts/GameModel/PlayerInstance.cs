using UnityEngine;
using UnityEngine.Serialization;

namespace GameModel
{
    public class PlayerInstance : RagdollInstance
    {
        [SerializeField] private InputManager input;
        [SerializeField] private CameraInstance playerCam;
        [SerializeField] private Transform camFollowTarget;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private Transform itemAttachPoint;
        [SerializeField] private float runSpeed = 2f;

        public InventoryManager GetInventoryManager => inventoryManager;
        public Transform GetItemAttachPoint => itemAttachPoint;
        
        protected override void Init()
        {
            base.Init();
            input.OnJumpInput += Jump;
            input.OnSwitchInventory += inventoryManager.Switch;
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetKey(KeyCode.LeftShift) && input.GetMovementInput().y > 0)
            {
                animController.TranslateCharacterSpeed(input.GetMovementInput().y * runSpeed,
                    input.GetMovementInput().x * runSpeed);
                movementDir = (transform.forward * input.GetMovementInput().y +
                               transform.right * input.GetMovementInput().x) * runSpeed;
            }
            else
            {
                animController.TranslateCharacterSpeed(input.GetMovementInput().y, input.GetMovementInput().x);
                movementDir = transform.forward * input.GetMovementInput().y +
                              transform.right * input.GetMovementInput().x;
            }

            if (Cursor.lockState == CursorLockMode.Locked)
                RotatePlayer();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }

            playerCam.FollowTarget(camFollowTarget);
        }

        private void RotatePlayer()
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");
            transform.RotateAround(transform.position, Vector3.up,
                rotateHorizontal);
            camFollowTarget.RotateAround(transform.position + Vector3.up, -camFollowTarget.right,
                rotateVertical);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            input.OnJumpInput -= Jump;
            input.OnSwitchInventory -= inventoryManager.Switch;
        }
    }
}