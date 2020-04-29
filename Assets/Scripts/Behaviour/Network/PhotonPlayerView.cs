using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PlayerController))]
public class PhotonPlayerView : MonoBehaviourPun
{
    private void Start()
    {
        if (!PhotonNetwork.IsConnected) return;

        if (!photonView.IsMine) Destroy(GetComponent<PlayerController>());
    }
}
