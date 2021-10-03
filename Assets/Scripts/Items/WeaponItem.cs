using UnityEngine;

namespace MilanGeorge
{
    
    [CreateAssetMenu(menuName = "Items/WeaponItem")]
    public class WeaponItem : Item
    {
        public GameObject weaponModelPrefab;
        public bool isUnarmed;
    }
}
