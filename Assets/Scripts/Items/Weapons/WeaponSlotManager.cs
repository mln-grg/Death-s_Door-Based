using UnityEngine;
namespace MilanGeorge
{
    public class WeaponSlotManager : MonoBehaviour
    {
        public WeaponHolderSlot leftHandSlot;
        public WeaponHolderSlot rightHandSlot;

        WeaponDamage leftWeaponDamage ;
        WeaponDamage rightWeaponDamage;

        PlayerInventory playerInventory;
        PlayerManager playerManager;
        WeaponHolderSlot[] weaponSlots;
        WeaponItem rightWeapon;

        bool weaponUnsheathed = false;

        [SerializeField] GameObject weaponDamageCentre;
        private void Awake()
        {
            playerInventory = GetComponent<PlayerInventory>();
            weaponSlots = GetComponentsInChildren<WeaponHolderSlot>();
            playerManager = GetComponent<PlayerManager>();
        }
        
        private void Start()
        {
            foreach (WeaponHolderSlot i in weaponSlots)
            {
                if (i.isLeftHand)
                {
                    leftHandSlot = i;
                    
                }
                else
                {
                    rightHandSlot = i;
                    
                }
            }
            weaponUnsheathed = false;
            HideWeapon();
        }

        public void LoadWeaponOnSlot(WeaponItem weapon , bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeapon(weapon,true);
                leftWeaponDamage = leftHandSlot.GetCurrentWeaponModel().GetComponentInChildren<WeaponDamage>();
            }
            else
            {
                rightHandSlot.LoadWeapon(weapon,false);
                rightWeapon = weapon;
                rightWeaponDamage = rightHandSlot.GetCurrentWeaponModel().GetComponentInChildren<WeaponDamage>();
            }
        }

        public void ShowWeapon()
        {
            weaponUnsheathed = true;
            playerInventory.ShowEquippedWeapon(false);
            foreach (WeaponHolderSlot i in weaponSlots)
            {
                i.gameObject.SetActive(true);

            }

        }

        public void CheckSphereForEnemies()
        {
            if (leftWeaponDamage != null)
                leftWeaponDamage.CheckSphere(weaponDamageCentre.transform.position,transform.rotation);

            if (rightWeaponDamage != null)
                rightWeaponDamage.CheckSphere(weaponDamageCentre.transform.position,transform.rotation);
        }
        public void DisableWeaponCollider()
        {
            /*if (leftWeaponDamage != null)
                leftWeaponDamage.WeaponColliderStatus(false);

            if (rightWeaponDamage != null)
                rightWeaponDamage.WeaponColliderStatus(false);*/
        }

        public void HideWeapon()
        {
           /* if (weaponUnsheathed)
                //playerManager.PlayTargetAnimation(rightWeapon.Sheathe, true);*/

            playerInventory.ShowEquippedWeapon(true);
            foreach (WeaponHolderSlot i in weaponSlots)
            {
                i.gameObject.SetActive(false);

            }
            weaponUnsheathed = false;
            DisableWeaponCollider();
        }


    }
}
