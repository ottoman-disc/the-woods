using UnityEngine;
using Photon.Pun;

public class PhotonSharedObject : MonoBehaviour, ITransferable
{
    public void Take(PhotonView taker)
    {
        PhotonView pv = this.GetComponent<PhotonView>();

        pv.RequestOwnership();
    }
}
