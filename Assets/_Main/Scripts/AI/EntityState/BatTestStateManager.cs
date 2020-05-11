using UnityEngine;

namespace OttomanDisc.AI
{
    public class BatTestStateManager : EntityStateManager
    {
        [Header("BAT")]

        [SerializeField] GameObject homePrefab;
        public Transform _home;

        private void Awake()
        {
            _home = Instantiate(homePrefab, this.transform.position, Quaternion.identity).transform;
        }

        public void GoHome()
        {
            MoveTowards(_home);
        }
    }
}
