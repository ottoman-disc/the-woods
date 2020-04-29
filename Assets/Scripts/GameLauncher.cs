using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace OttomanDisk
{
    // Handles launching a new game from the title screen using PUN
    // PUN library provides MonoBehaviourCallbacks class to simplyfy implementing callbacks
    public class GameLauncher : MonoBehaviourPunCallbacks
    {
        // Private fields
        string gameVersion = "1"; // increment for breaking changes to networking
        byte maxPlayers = 4; // define maximum allowed players in the room
        bool userRequestedConnection; // determine if the user requested a connection

        [SerializeField]
        private GameObject menuPanel;

        [SerializeField]
        private GameObject statusText;

        [SerializeField] private string gameScene = "Input-sm";

        // MonoBehaviour Callbacks
        void Awake()
        {
            // this allows the master client to load levels for all players
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            menuPanel.SetActive(true);
            statusText.SetActive(false);
        }

        // MonoBehaviousPunCallbacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster() called");
            // when returning to the title screen this callback is triggered again
            // only join a game is it was a user request
            if (userRequestedConnection)
            {
                Join();
            }
        }

        public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
        {
            Debug.LogWarningFormat("Disconnected from PUN with reason '{0}'", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions
            {
                MaxPlayers = maxPlayers
            });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room");
            PhotonNetwork.LoadLevel(gameScene);
        }

        // Other Methods
        public void Connect()
        {
            menuPanel.SetActive(false);
            statusText.SetActive(true);

            if (PhotonNetwork.IsConnected)
            {
                Join();
            }
            else
            {
                userRequestedConnection = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
                // calback will handle Join() in this case
            }
        }

        private void Join()
        {
            // placeholder for better join logic
            PhotonNetwork.JoinRandomRoom();
        }
    }

}
