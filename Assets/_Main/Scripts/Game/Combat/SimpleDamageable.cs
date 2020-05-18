using UnityEngine;
using UnityEngine.SceneManagement;

namespace OttomanDisc
{
    public class SimpleDamageable : MonoBehaviour, IDamageable
    {
        public void DamageReceived(IDamage damageValue)
        {
            SceneManager.LoadScene("Game DS");
        }
    }
}
