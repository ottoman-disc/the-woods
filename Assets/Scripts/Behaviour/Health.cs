using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Convenience class for managing networked health of game objects. 
// Add this script to a object along with a PhotonView component and hook this
// script up as an observed component
public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public float CurrentHealth {get; set; } = 1f;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.CurrentHealth);
        }
        else
        {
            this.CurrentHealth = (float)stream.ReceiveNext();
        }
    }
}
