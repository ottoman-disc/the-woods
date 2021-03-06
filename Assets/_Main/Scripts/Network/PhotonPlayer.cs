﻿using Photon.Pun;
using UnityEngine;

namespace OttomanDisc.Network
{
    public class PhotonPlayer : MonoBehaviourPun
    {
        public Object[] destroyIfNotConnected; // objects to remove when testing w/o network
        public Object[] destroyIfRemote; // objects to remove if player is remote


        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                RemoveObjects(destroyIfNotConnected);
                Destroy(this);
                return;
            }
            else
            {
                if (photonView.IsMine)
                {
                    this.name = "PLAYER: LOCAL";
                }
                else
                {
                    this.name = "PLAYER: REMOTE";
                    RemoveObjects(destroyIfRemote);
                }
            }
        }

        private void RemoveObjects(Object[] objects)
        {
            foreach (var obj in objects)
            {
                Debug.LogFormat("Removing object: {0}", obj);
                Destroy(obj);
            }
        }
    }
}
