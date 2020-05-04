using UnityEngine;

namespace OttomanDisc
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private GameObject[] gameObjectsToDestroy;
        [SerializeField] private MonoBehaviour[] componentsToDestroy;
 
        public void Activate()
        {
            foreach (GameObject go in gameObjectsToDestroy)
                Destroy(go);

            foreach (MonoBehaviour mb in componentsToDestroy)
                Destroy(mb);
        }
    }
}
