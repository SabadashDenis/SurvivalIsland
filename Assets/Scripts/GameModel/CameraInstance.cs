using UnityEngine;

namespace GameModel
{
    public class CameraInstance : Instance
    {
        [SerializeField] private float posLerp = 0.2f; 
        [SerializeField] private float rotLerp = 0.1f; 

        protected override void Init()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        
        public void FollowTarget(Transform target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, posLerp);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotLerp);
        }
    }
}