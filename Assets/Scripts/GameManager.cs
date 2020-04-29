using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace OttomanDisk
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerPrefab; 

        // Monobehaviour Methods
        void Start()
        {
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
            }
            else 
            {
                Debug.Log("Instantiating local player");
                //PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(1f,2f,0f), Quaternion.identity, 0);
            }
        }

        void Update()
        {

        }

        // MonobehaviourPunCallbacks Methods
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        // public override void OnPlayerEnteredRoom(Player newPlayer)
        // {
        //     Debug.Log("A new player has entered room");

        //     if (PhotonNetwork.IsMasterClient)
        //     {
        //         // only the master has rights to load a new scene
        //         LoadArea();
        //     }
        // }

        // Other Methods
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        // private void LoadArea()
        // {
        //     if (!PhotonNetwork.IsMasterClient)
        //     {
        //         Debug.LogError("non master trying to load level??");
        //     }
        //     PhotonNetwork.LoadLevel(1);
        // }

    }

}
