using UnityEngine;
namespace MilanGeorge
{
    public class PlayerStats : MonoBehaviour
    {
        PlayerManager playerManager;
        [SerializeField] private HealthContainer healthContainer;
        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        const string GetHit = "GetHit";
        const string Death = "Death";

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        private void Start()
        {
            RefreshHealthUI();
        }
        public void SetMaxHealth(int value)
        {
            maxHealth += value;
            RefreshHealthUI();
        }

        public void TakeDamage()
        {
            currentHealth--;

            Effects.instance.PlayerTookDamage();
            
            RefreshHealthUI();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                playerManager.PlayTargetAnimation(Death, true);
                //HandlePlayerDeath
            }
            else
                playerManager.PlayTargetAnimation(GetHit, true);     
        }


        
        private void RefreshHealthUI()
        {
            healthContainer.UpdateHearts(maxHealth, currentHealth);
        }
    }
}
