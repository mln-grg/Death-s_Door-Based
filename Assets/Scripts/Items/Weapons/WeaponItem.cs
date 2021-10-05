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

        public int LightcomboCount;
        public int HeavycomboCount;

        public string[] Lightattacks;
        public string[] Heavyattacks;
    
    }
}
