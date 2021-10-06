using UnityEngine;

namespace MilanGeorge
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private HealthContainer healthContainer;   

        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

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
            RefreshHealthUI();
        }

        private void RefreshHealthUI()
        {
            healthContainer.UpdateHearts(maxHealth, currentHealth);
        }
    }
}
