using UnityEngine;


namespace MilanGeorge {
    public class Test : MonoBehaviour
    {
        public float expForce;
        public float radius;
        private void Update()
        {
            
        }
        private void OnTriggerEnter(Collider other)
        {
            PlayerStats p = other.GetComponent<PlayerStats>();
            //other.GetComponent<Rigidbody>().AddExplosionForce(expForce, transform.position, radius);
            p.TakeDamage();
        }
    }
}