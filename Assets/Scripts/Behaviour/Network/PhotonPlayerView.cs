using Cinemachine;
using Photon.Pun;

public class PhotonPlayerView : MonoBehaviourPun
{
    private void Start()
    {
        if (!PhotonNetwork.IsConnected) return;

        if (!photonView.IsMine)
        {
            // Remote player does not need a Controller or Motor. Movement driven
            // by them locally, and synced to us.
            Destroy(GetComponent<PlayerController>());
            Destroy(GetComponent<Motor>());

            // Remote player should not have a Cinemachine Virtual Camera,
            // since we only want one camera in the scene
            Destroy(GetComponent<CinemachineVirtualCamera>().gameObject);
        }

        // This componenet has now done its job, so we can also Destroy it
        Destroy(this);
    }
}
