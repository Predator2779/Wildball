// using UnityEngine;
// using UnityEngine.UI;
// using Photon.Pun;
// using Photon.Realtime;
//
// public class LobbyManager : MonoBehaviourPunCallbacks
// {
//     [SerializeField] private Text _logText;
//     [SerializeField] private string _nameStartScene;
//     [SerializeField] private string _nameMenuScene;
//
//     private void Start()
//     {
//         StartConnection();
//     }
//
//     public void StartConnection()///////////////////////// �� ������������ � ������� ��� ��������� �������������. �������� ��-�� ����, ��� ������ ��������� � STARTE. ???
//     {
//         PhotonNetwork.NickName = "Player_" + Random.Range(1000, 9999);
//
//         Log("Player's name is set to " + PhotonNetwork.NickName);
//
//         PhotonNetwork.AutomaticallySyncScene = true;
//         PhotonNetwork.GameVersion = "1";
//
//         PhotonNetwork.ConnectUsingSettings();
//     }
//
//     public void CreateRoom()
//     {
//         PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 3 });///
//     }
//
//     public void JoinRoom()
//     {
//         PhotonNetwork.JoinRandomRoom();
//     }
//
//     public void DisconnectRoom()
//     {
//         PhotonNetwork.LeaveLobby();
//         PhotonNetwork.Disconnect();
//
//         PhotonNetwork.LoadLevel(_nameMenuScene);
//     }
//
//     public override void OnConnectedToMaster()
//     {
//         Log("Connected to Master");
//     }
//
//     public override void OnJoinedRoom()
//     {
//         Log("Joined the room");
//
//         PhotonNetwork.LoadLevel(_nameStartScene);
//     }
//
//     public override void OnJoinedLobby()
//     {
//         Log("Player joined lobby");
//     }
//
//     public override void OnLeftLobby()
//     {
//         Log("Player left lobby");
//     }
//
//     public override void OnLeftRoom()
//     {
//         Log("Player left room");
//     }
//
//     public override void OnMasterClientSwitched(Player newMasterClient)
//     {
//         Log($"MasterClient switched. New MasterClient: {newMasterClient}");
//     }
//
//     public override void OnJoinRandomFailed(short returnCode, string message)
//     {
//         Log($"Join Random Failed. ErrorCode: {returnCode}; Message: {message}.");
//     }
//
//     public override void OnDisconnected(DisconnectCause cause)
//     {
//         Log("Disconnected");
//     }
//
//     private void Log(string message)
//     {
//         Debug.Log(message);
//
//         _logText.text += "\n";
//         _logText.text += message;
//     }
// }