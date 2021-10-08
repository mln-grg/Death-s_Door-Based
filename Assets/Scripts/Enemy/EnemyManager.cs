using UnityEngine;

namespace MilanGeorge
{
    public class EnemyManager : MonoBehaviour
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayTargetAnimation(string name)
        {
            animator.CrossFade(name, 0.1f); 
        }

    }
}