using UnityEngine;

namespace MilanGeorge
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        [SerializeField] WeaponItem rightHandWeapon;

        [SerializeField] GameObject EquippedWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }


        private void Start()
        {
            if (rightHandWeapon.hasWeaponforOffhand)
            {
                weaponSlotManager.LoadWeaponOnSlot(rightHandWeapon, true);
            }
                
            weaponSlotManager.LoadWeaponOnSlot(rightHandWeapon, false);

            ShowEquippedWeapon(true);
        }

        #region Getters

        public WeaponItem GetLeftHandWeapon()
        {
            if (rightHandWeapon.hasWeaponforOffhand)
            {
                return rightHandWeapon;
            }

            return null;
        }
        public WeaponItem GetRightHandWeapon()
        {
            return rightHandWeapon;
        }
        #endregion
        #region Setters
        public void SetEquippedWeapon(WeaponItem weapon)
        {
            //Later
        }
        #endregion
        public void ShowEquippedWeapon(bool value)
        {
            EquippedWeapon.SetActive(value);
        }
    }
}
