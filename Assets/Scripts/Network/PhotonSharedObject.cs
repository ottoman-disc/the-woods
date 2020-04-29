using Photon.Pun;
using UnityEngine;

namespace OttomanDisc
{
    public class PhotonSharedObject : MonoBehaviour
    {
        public void Take(GameObject taker)
        {
            if (!taker.GetComponent<PhotonView>().IsMine) return;

            this.name = "OWNED BY " + taker.name;

            PhotonView pv = this.GetComponent<PhotonView>();
            pv.RequestOwnership();
        }
    }
}
