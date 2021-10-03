using UnityEngine;

namespace MilanGeorge
{
    public class PlayerCombatManager : MonoBehaviour
    {
        PlayerManager playerManager;

        const string Shoot = "Shooting";

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        public void HandleShooting()
        {
            if (playerManager.GetIsInteracting())
                return;

            if (playerManager.GetIsShooting())
                playerManager.PlayTargetAnimation(Shoot, false);
        }
    }
}
