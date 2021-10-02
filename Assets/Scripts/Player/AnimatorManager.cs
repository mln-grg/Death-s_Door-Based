using UnityEngine;
namespace MilanGeorge
{
    public class AnimatorManager : MonoBehaviour
    {
        [HideInInspector]
        public Animator animator;
        int horizontal;
        int vertical;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            horizontal = Animator.StringToHash("Horizontal");
            vertical = Animator.StringToHash("Vertical");
        }



        public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
        {
            animator.applyRootMotion = isInteracting;
            animator.SetBool("isInteracting", isInteracting);
            animator.CrossFade(targetAnimation, 0.2f);
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            horizontalMovement = SnapValue(horizontalMovement);
            verticalMovement = SnapValue(verticalMovement);

            animator.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
            animator.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
        }

        float SnapValue(float x)
        {
            if (x > 0 && x < 0.5f)
                return 0.5f;
            else if (x > 0.5 && x < 1)
                return 1;
            return x;
        }
    }
}
