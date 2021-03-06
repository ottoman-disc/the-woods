﻿using OttomanDisc.Network;
using UnityEngine;

namespace OttomanDisc
{
    public class Tree : PhotonSharedObject, IInteractable, IDamage
    {
        public int Damage { get; } = 5;

        public void Interact()
        {
            ColorSetter colorSetter = this.GetComponent<ColorSetter>();
            if (colorSetter != null)
                colorSetter.SetColorAndBroadcast(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DamageReceived(this);
            }
        }
    }
}
