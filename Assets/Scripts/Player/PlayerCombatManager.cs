using UnityEngine;

namespace MilanGeorge
{
    public class PlayerCombatManager : MonoBehaviour
    {
        PlayerManager playerManager;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        public void HandleLightAttack()
        {
            if (!playerManager.GetLightAttack())
                return;

            playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().attack1,true);


        }

        public void HandleAllAttacks()
        {
            HandleLightAttack();
        }
    }
}
