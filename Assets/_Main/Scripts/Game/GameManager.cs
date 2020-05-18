using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OttomanDisk
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerPrefab;
        [SerializeField] private Transform playerStartingTransform;
        private Vector3 _playerStartingPos = Vector3.zero;

        // Monobehaviour Methods
        void Start()
        {
            InstantiatePlayer();
            //ConfigureCamera();
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

        private void InstantiatePlayer()
        {
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
                return;
            }

            if (playerStartingTransform != null) _playerStartingPos = playerStartingTransform.position;

            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("Instantiating network player");
                PhotonNetwork.Instantiate(this.playerPrefab.name, _playerStartingPos, Quaternion.identity, 0);
            }
            else
            {
                Debug.Log("Instantiating local player");
                Instantiate(this.playerPrefab, _playerStartingPos, Quaternion.identity);
            }
        }

        // private void ConfigureCamera()
        // {
        //     if (virtualCamera == null)
        //     {
        //         Debug.LogError("<Color=Red><a>Missing</a></Color> virtualCamera Reference. Please set it up in GameObject 'Game Manager'", this);
        //         return;
        //     }

        //     virtualCamera.LookAt = _instantiatedPlayer.transform;
        //     virtualCamera.Follow = _instantiatedPlayer.transform;
        // }

    }

}
