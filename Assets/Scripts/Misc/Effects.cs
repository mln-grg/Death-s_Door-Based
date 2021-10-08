using UnityEngine;
using System.Collections;
using EZCameraShake;

namespace MilanGeorge
{
    public class Effects : MonoBehaviour
    {

        public static Effects instance = null;

        [Header("TimeFreeze")]
        [SerializeField] float timeToFreezePlayer;
        [SerializeField] float timeToFreezeEnemy;
        [SerializeField] float timeScaleValueForPlayer;
        [SerializeField] float timeScaleValueForEnemy;

        [Header("Camera Shake")]
        [SerializeField] float magnitude;
        [SerializeField] float roughness;
        [SerializeField] float fadeInTime;
        [SerializeField] float fadeOutTime;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
        }

        public void PlayerTookDamage()
        {
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            StartCoroutine(FreezeTime(timeToFreezePlayer,timeScaleValueForPlayer));
        }

        public void EnemyTookDamage()
        {
            StartCoroutine(FreezeTime(timeToFreezeEnemy,timeScaleValueForEnemy));
        }

        IEnumerator FreezeTime(float timeToFreeze,float timeScaleValue)
        {
            Time.timeScale = timeScaleValue;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            float pauseTimeFor = Time.realtimeSinceStartup + timeToFreeze;

            while (Time.realtimeSinceStartup < pauseTimeFor)
            {
                yield return 0;
            }
            Time.timeScale = 1; 
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
