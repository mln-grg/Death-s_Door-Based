using UnityEngine;

namespace MilanGeorge
{
    public class PlayerCombatManager : MonoBehaviour
    {
        PlayerManager playerManager;

        string lastAttack;
        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }

        private void HandleLightCombo()
        {
            bool attackPerformed = false;
            if (playerManager.GetCanDoCombo())
            {
                for(int i=0; i< playerManager.GetRightHandWeapon().LightcomboCount; i++)
                {
                    if(i== playerManager.GetRightHandWeapon().LightcomboCount - 1)
                    {
                        playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Lightattacks[0], true);
                        lastAttack = playerManager.GetRightHandWeapon().Lightattacks[0];
                        attackPerformed = true;

                        break;
                    }
                    else if(lastAttack == playerManager.GetRightHandWeapon().Lightattacks[i])
                    {
                        playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Lightattacks[i+1], true);
                        lastAttack = playerManager.GetRightHandWeapon().Lightattacks[i + 1];
                        attackPerformed = true;

                        break;
                    }
                    
                }

                if (!attackPerformed)
                {
                    playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Lightattacks[0], true);
                    lastAttack = playerManager.GetRightHandWeapon().Lightattacks[0];

                }
            }
        }

        private void HandleHeavyCombo()
        {
            bool attackPerformed = false;


            for (int i = 0; i < playerManager.GetRightHandWeapon().HeavycomboCount; i++)
            {
                if (i == playerManager.GetRightHandWeapon().HeavycomboCount - 1)
                {
                    playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Heavyattacks[0], true);
                    lastAttack = playerManager.GetRightHandWeapon().Heavyattacks[0];
                    attackPerformed = true;
                    break;
                }
                else if (lastAttack == playerManager.GetRightHandWeapon().Heavyattacks[i])
                {
                    playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Heavyattacks[i + 1], true);
                    lastAttack = playerManager.GetRightHandWeapon().Heavyattacks[i + 1];
                    attackPerformed = true;
                    break;
                }

            }

            if (!attackPerformed)
            {
                playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Heavyattacks[0], true);
                lastAttack = playerManager.GetRightHandWeapon().Heavyattacks[0];
            }

        }

        public void HandleLightAttack()
        {
            if (!playerManager.GetLightAttack())
                return;
            if (playerManager.GetIsInteracting())
                return;
            if (playerManager.GetCanDoCombo())
            {
                HandleLightCombo();
                return;
            }
            playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Lightattacks[0], true);
            lastAttack = playerManager.GetRightHandWeapon().Lightattacks[0];


        }

        public void HandleHeavyAttack()
        {
            if (!playerManager.GetHeavyAttack())
                return;
            if (playerManager.GetIsInteracting())
                return;
            if (playerManager.GetCanDoCombo())
            {
                HandleHeavyCombo();
                return;
            }
            playerManager.PlayTargetAnimation(playerManager.GetRightHandWeapon().Heavyattacks[0], true);
            lastAttack = playerManager.GetRightHandWeapon().Heavyattacks[0];

        }

        public void HandleAllAttacks()
        {
            HandleLightAttack();
            HandleHeavyAttack();
        }
    }
}
