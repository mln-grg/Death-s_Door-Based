using UnityEngine;
namespace MilanGeorge 
{
    public class WeaponHolderSlot : MonoBehaviour
    {
        [SerializeField] private Transform parentOverride;

        public bool isLeftHand;

        GameObject currentWeapon;
        public void UnloadWeapon()
        {
            if(currentWeapon!=null)
                currentWeapon.SetActive(false);
        }

        public void UnloadWeaponAndDestroy()
        {
            if (currentWeapon != null)
                Destroy(currentWeapon);

        }
        public void LoadWeapon(WeaponItem weaponItem,bool offHand)
        {
            if(weaponItem == null)
            {
                UnloadWeapon();
                return;
            }
            GameObject weapon;

            if (offHand)
            {
                if (weaponItem.weaponModelPrefabOffhand != null)
                {
                    weapon = Instantiate(weaponItem.weaponModelPrefabOffhand) as GameObject;
                    currentWeapon = weapon;
                }
                else
                {
                    weapon = Instantiate(weaponItem.weaponModelPrefab) as GameObject;
                    currentWeapon = weapon;
                }
            }
            else
            {
                weapon = Instantiate(weaponItem.weaponModelPrefab) as GameObject;
                currentWeapon = weapon;
            }
            //weapon.transform.localScale

            

            if (parentOverride != null)
            {
                currentWeapon.transform.parent = parentOverride;
            }
            else
            {
                currentWeapon.transform.parent = transform;
            }

            currentWeapon.transform.localPosition = Vector3.zero;
            //weapon.transform.localScale = Vector3.one;
            currentWeapon.transform.localRotation = Quaternion.identity;

            //currentWeapon.SetActive(false);
        }

        public void ShowWeaponOnHand(bool value)
        {
            if (currentWeapon!= null)
                currentWeapon.SetActive(value);
        }

        public GameObject GetCurrentWeaponModel()
        {
            return currentWeapon;
        }
    }
}