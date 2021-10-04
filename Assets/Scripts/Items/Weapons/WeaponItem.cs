using UnityEngine;

namespace MilanGeorge
{
    
    [CreateAssetMenu(menuName = "Items/WeaponItem")]
    public class WeaponItem : Item
    {
        public GameObject weaponModelPrefab;
        public GameObject weaponModelPrefabOffhand;
        public GameObject WeaponModelPrefabEquipped;

        public bool isUnarmed;
        public bool hasWeaponforOffhand;

        [Header("OneHandedAttackAnimations")]
        public string attack1;
        public string attack2;
        public string attack3;
    }
}
