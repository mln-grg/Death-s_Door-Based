using UnityEngine;
namespace MilanGeorge
{
    public class EnemyStats : MonoBehaviour
    {
        EnemyManager enemyManager;
        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        const string GetHit = "GetHit";
        const string Death = "Death";

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        public void TakeDamage()
        {
            currentHealth--;
            Effects.instance.EnemyTookDamage();
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                enemyManager.PlayTargetAnimation(Death);
            }
            else
            {
                enemyManager.PlayTargetAnimation(GetHit);
            }
        }
    }
}