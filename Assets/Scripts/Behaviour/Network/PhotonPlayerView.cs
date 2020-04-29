using Photon.Pun;
using UnityEngine;

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

            // Remote player does not need a Camera, or AudioListener, so we simply
            // search for the Object with the Camera, and delete it entirely since
            // it also has the AudioListener attached.
            Destroy(GetComponentInChildren<Camera>().gameObject);

        }

        // This componenet has now doen its job, so we can also Destroy it
        Destroy(this);
    }
}
