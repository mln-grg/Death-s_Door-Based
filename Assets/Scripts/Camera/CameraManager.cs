using UnityEngine;

namespace MilanGeorge
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager instance = null;

        [SerializeField] float cameraFollowSpeed;
        Vector3 currentVelocity = Vector3.zero;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public void FollowTarget(Vector3 targetPosition)
        {
            Vector3 target = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, cameraFollowSpeed);

            transform.position = target;
        }
    }
}
