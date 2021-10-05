using UnityEngine;
namespace MilanGeorge
{
    public class WeaponSlotManager : MonoBehaviour
    {
       public WeaponHolderSlot leftHandSlot;
       public WeaponHolderSlot rightHandSlot;
        PlayerInventory playerInventory;
       WeaponHolderSlot[] weaponSlots;
        private void Awake()
        {
            playerInventory = GetComponent<PlayerInventory>();
            weaponSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach(WeaponHolderSlot i in weaponSlots)
            {
                if (i.isLeftHand)
                    leftHandSlot = i;
                else
                    rightHandSlot = i;
            }

            
        }

        private void Start()
        {
            HideWeapon();
        }

        public void LoadWeaponOnSlot(WeaponItem weapon , bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeapon(weapon,true);
            }
            else
            {
                rightHandSlot.LoadWeapon(weapon,false);
            }
        }

        public void ShowWeapon()
        {
            playerInventory.ShowEquippedWeapon(false);
            foreach (WeaponHolderSlot i in weaponSlots)
            {
                i.gameObject.SetActive(true);
            }

        }

        public void HideWeapon()
        {
            playerInventory.ShowEquippedWeapon(true);
            foreach (WeaponHolderSlot i in weaponSlots)
            {
                i.gameObject.SetActive(false);

            }
        }
    }
}
