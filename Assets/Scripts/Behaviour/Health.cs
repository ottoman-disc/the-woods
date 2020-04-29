using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace OttomanDisc
{
    // Convenience class for managing networked health of game objects. 
    // Add this script to a object along with a PhotonView component and hook this
    // script up as an observed component
    public class Health : MonoBehaviourPun, IPunObservable, IDamageable
    {
        [SerializeField]
        private int _maxHealth = 200; // the maximum/startng health

        [SerializeField]
        private Image _healthBar;

        [SerializeField]
        private Text _healthText;
        private int _health; // the current health
        private float _healthPercent; // the current health% expressed as a float


        private void Awake()
        {
            _health = _maxHealth;
            UpdateHealthBar();
        }

        public void DamageReceived(IDamage damage)
        {
            if (! photonView.IsMine)
            {
                return;
            }

            _health -= damage.Damage;
            Debug.LogFormat("Damage {0}, Health = {1}", damage.Damage, _health);
            UpdateHealthBar();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(this._health);
            }
            else
            {
                this._health = (int)stream.ReceiveNext();
            }
        }

        private void UpdateHealthBar()
        {
            _healthPercent = (float)_health / (float)_maxHealth;
            if (_healthBar != null)
            {
                _healthBar.fillAmount = _healthPercent;
            }
            if (_healthText != null)
            {
                _healthText.text = _health.ToString();
            }

        }
    }
}
