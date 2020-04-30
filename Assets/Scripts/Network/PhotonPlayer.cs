using Cinemachine;
using Photon.Pun;

namespace OttomanDisc
{
    public class PhotonPlayer : MonoBehaviourPun
    {
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

                // Remote player does not need a Controller or Motor. Movement driven
                // by them locally, and synced to us.
                Destroy(GetComponent<PlayerController>());
                Destroy(GetComponent<Motor>());
                Destroy(GetComponent<Interactor>());

                // Remote player should not have a Cinemachine Virtual Camera,
                // since we only want one camera in the scene
                Destroy(GetComponentInChildren<CinemachineVirtualCamera>().gameObject);
            }

            // This componenet has now done its job, so we can also Destroy it
            Destroy(this);
        }
    }
}
