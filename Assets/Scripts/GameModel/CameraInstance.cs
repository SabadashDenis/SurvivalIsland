using System;
using UnityEngine;

namespace GameModel
{
    public class CameraInstance : Instance
    {
        [SerializeField] private float camSensitivity;

        private float xRot = 0f;
        private float yRot = 0f;

        protected override void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void Activate(bool condition)
        {
            base.Activate(condition);

            xRot = transform.rotation.x;
            yRot = transform.rotation.y;
        }

        private void Update()
        {
            yRot -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camSensitivity;
            xRot += Input.GetAxisRaw("Mouse X") * Time.deltaTime * camSensitivity;

            yRot = Mathf.Clamp(yRot, -70f, 70f);

            transform.rotation = Quaternion.Euler(yRot, xRot, 0);
        }
    }
}