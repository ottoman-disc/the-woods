using Cinemachine;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace OttomanDisc
{
    public class PhotonPlayer : MonoBehaviourPun
    { 
        [SerializeField] UnityEvent remotePlayerEvent;

        private void Start()
        {
            if (!PhotonNetwork.IsConnected) return;

            if (photonView.IsMine)
            {
                this.name = "PLAYER: LOCAL";
            }
            else
            {
                this.name = "PLAYER: REMOTE";

                remotePlayerEvent.Invoke();
            }
        }
    }
}
