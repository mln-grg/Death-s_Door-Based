using UnityEngine;  
using UnityEngine.UI;  

namespace MilanGeorge {
    public class HealthContainer : MonoBehaviour
    {
        [SerializeField] Image[] HealthContainers;
        [SerializeField] Sprite EmptyHeartContainer;
        [SerializeField] Sprite FilledHeartContainer;


        public void UpdateHearts(int maxHearts,int currentHealth)
        {
            for(int i = 0; i < HealthContainers.Length; ++i)
            {
                if (i < currentHealth)
                {
                    HealthContainers[i].sprite = FilledHeartContainer;
                    HealthContainers[i].enabled = true;
                }
                else if (i < maxHearts)
                {
                    HealthContainers[i].sprite = EmptyHeartContainer;
                    HealthContainers[i].enabled = true;
                }
                else
                    HealthContainers[i].enabled = false;
            }
        }
    } 
}
