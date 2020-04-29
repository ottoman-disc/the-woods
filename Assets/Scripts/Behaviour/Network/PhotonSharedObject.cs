using UnityEngine;
using Photon.Pun;

public class PhotonSharedObject : MonoBehaviour, ITransferable
{
    public void Transfer()
    {
        PhotonView pv = this.GetComponent<PhotonView>();

        pv.RequestOwnership();
    }
}
