// using Managers;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using Photon.Pun;
// using Photon.Realtime;
// using UnityEngine.Serialization;
//
// public class NetworkManager : MonoBehaviourPunCallbacks
// {
//     [FormerlySerializedAs("_gameplayManager")] [SerializeField] private GameSettings gameSettings;
//     [SerializeField] private GameObject _playerPrefab;
//     [SerializeField] private string _loadScene;
//
//     private void Start()
//     {
//         var playerPos = new Vector3(Random.Range(-35, 35), 6, Random.Range(-35, 35));
//
//         PhotonNetwork.Instantiate(_playerPrefab.name, playerPos, Quaternion.identity);
//     }
//
//     public override void OnLeftRoom()
//     {
//         /// Когда текущий игрок (мы) покидает комнату.
//
//         SceneManager.LoadScene(_loadScene);
//     }
//
//     public void LeaveRoom()
//     {
//         PhotonNetwork.LeaveRoom();
//         PhotonNetwork.Disconnect();
//
//         gameSettings.ToMenu();
//     }
//
//     public override void OnPlayerEnteredRoom(Player newPlayer)
//     {
//         Debug.LogFormat("Player {0} entered the room", newPlayer.NickName);
//     }
//
//     public override void OnPlayerLeftRoom(Player otherPlayer)
//     {
//         Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
//     }
// }
