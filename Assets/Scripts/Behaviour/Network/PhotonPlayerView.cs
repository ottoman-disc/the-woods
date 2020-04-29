using Photon.Pun;
using UnityEngine;

public class PhotonPlayerView : MonoBehaviourPun
{
    private void Start()
    {
        if (!PhotonNetwork.IsConnected) return;

        if (!photonView.IsMine)
        {
            Destroy(GetComponent<PlayerController>());
            Destroy(GetComponent<Motor>());
        }
    }
}
