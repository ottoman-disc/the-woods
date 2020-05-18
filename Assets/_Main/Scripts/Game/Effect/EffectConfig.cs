using UnityEngine;

namespace OttomanDisc
{
    [CreateAssetMenu(fileName = "Effect", menuName = nameof(OttomanDisc) + "/" + nameof(EffectConfig))]
    public class EffectConfig : ScriptableObject
    {
        [SerializeField] GameObject prefabToSpawn;

        public void Spawn(Vector3 position, Quaternion rotation)
        {
            Instantiate(prefabToSpawn, position, rotation);
        }

        public void Spawn(Vector3 position)
        {
            Spawn(position, default);
        }
    }
}
