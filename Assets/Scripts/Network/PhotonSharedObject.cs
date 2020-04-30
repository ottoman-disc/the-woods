using Photon.Pun;
using UnityEngine;

namespace OttomanDisc
{
    public class PhotonSharedObject : MonoBehaviour
    {
        string originalName;

        private void Start()
        {
            originalName = this.name;
        }

        public void Take(GameObject taker)
        {
            this.name = originalName + " [" + taker.name + "]";

            if (!taker.GetComponent<PhotonView>().IsMine) return;

           // PhotonView pv = this.GetComponent<PhotonView>();
            //pv.RequestOwnership();

            taker.GetComponent<PhotonView>().ObservedComponents.Add(this.GetComponent<PhotonTransformView>());
        }
    }
}
