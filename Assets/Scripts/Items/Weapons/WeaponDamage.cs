using UnityEngine;

namespace MilanGeorge
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] Vector3 damageRadius;
        [SerializeField] Vector3 offset;

        Vector3 ORIGIN;
        public bool isWeaponOnBack;
        private void Awake()
        {

            gameObject.SetActive(true);
            this.enabled = true;

        }

        public void CheckSphere(Vector3 origin,Quaternion orientation)
        {
            ORIGIN = origin;
            Collider[] colliders = Physics.OverlapBox(origin, damageRadius,orientation);

            foreach(Collider x in colliders)
            {
                if (x.tag == "Enemy")
                {
                    EnemyStats enemyStats = x.GetComponent<EnemyStats>();
                    enemyStats.TakeDamage();
                }
                else if (x.tag == "Hittable")
                {

                }
            }

        }

        
    }
}
