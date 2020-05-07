using Cinemachine;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace OttomanDisc
{
    public class PhotonPlayer : MonoBehaviourPun
    {
        public Object[] destroyIfNotConnected; // objects to remove when testing w/o network
        public Object[] destroyIfRemote; // objects to remove if player is remote


        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                RemoveBehaviours(destroyIfNotConnected);
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
                    RemoveBehaviours(destroyIfRemote);
                }
            }
        }

        private void RemoveBehaviours(Object[] objects)
        {
            foreach (var obj in objects)
            {
                Debug.LogFormat("Removing object: {0}", obj);
                Destroy(obj);
            }
        }
    }
}
