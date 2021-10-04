using UnityEngine;
namespace MilanGeorge
{
    public class WeaponSlotManager : MonoBehaviour
    {
       public WeaponHolderSlot leftHandSlot;
       public WeaponHolderSlot rightHandSlot;

        private void Awake()
        {
            WeaponHolderSlot[] weaponSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach(WeaponHolderSlot i in weaponSlots)
            {
                if (i.isLeftHand)
                    leftHandSlot = i;
                else
                    rightHandSlot = i;
            }
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
    }
}
