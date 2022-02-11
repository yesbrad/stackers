using UnityEngine;

namespace Core
{
    public class GridNode : MonoBehaviour
    {
        [SerializeField] private GameObject onContainer;
        [SerializeField] private GameObject offContainer;

        public GridNode Init()
        {
            Activate(false);
            return this;
        }
        
        public void Activate(bool isOn)
        {
            onContainer.SetActive(isOn);
            offContainer.SetActive(!isOn);
        }
    }
}