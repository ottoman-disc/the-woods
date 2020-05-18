using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace OttomanDisc
{
    // Handles launching a new game from the title screen using PUN
    // PUN library provides MonoBehaviourCallbacks class to simplyfy implementing callbacks
    public class GameLauncher : MonoBehaviourPunCallbacks
    {
        // Private fields
        private string gameVersion = "1"; // increment for breaking changes to networking
        private byte maxPlayers = 4; // define maximum allowed players in the room
        private bool userRequestedConnection; // determine if the user requested a connection
        private int nextSceneIndex = 1;


        [SerializeField]
        private GameObject menuPanel;

        [SerializeField]
        private GameObject statusText;

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

        // public override void OnJoinRandomFailed(short returnCode, string message)
        // {
        //     PhotonNetwork.CreateRoom(null, new RoomOptions
        //     {
        //         MaxPlayers = maxPlayers
        //     });
        // }

        public override void OnJoinedRoom()
        {
            var roomName = PhotonNetwork.CurrentRoom.Name;
            Debug.Log($"Joined {roomName}");
            PhotonNetwork.LoadLevel(nextSceneIndex);
        }

        // Other Methods
        public void Connect(int sceneIndex = 1)
        {
            menuPanel.SetActive(false);
            statusText.SetActive(true);
            nextSceneIndex = sceneIndex;

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

        // joins an existing room based on the nextSceneIndex
        // room is created if not already present
        private void Join()
        {
            var roomName = $"room_{nextSceneIndex}";
            var roomOpts = new RoomOptions{
                MaxPlayers = maxPlayers
            };
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOpts, TypedLobby.Default);
        }
    }
}
