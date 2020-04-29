using Photon.Pun;
using UnityEngine;

public class PhotonSharedObject : MonoBehaviour
{
    public void Take(GameObject taker)
    {
        if (!taker.GetComponent<PhotonView>().IsMine) return;

        PhotonView pv = this.GetComponent<PhotonView>();

        pv.RequestOwnership();
    }
}
