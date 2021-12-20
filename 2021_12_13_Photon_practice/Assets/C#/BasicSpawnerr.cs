using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fusion;           //�ޥ�Fusion�R�W�Ŷ�
using Fusion.Sockets;
using System.Collections.Generic;
using System;

//INetworkRunnerCallbacks �s�u���澹�^�I����.Runner���澹�B�z�欰��|�^�I����������k
/// <summary>
/// �s�u�򩳥ͦ���
/// </summary>
public class BasicSpawnerr : MonoBehaviour, INetworkRunnerCallbacks
{
    #region ���
    [Header("�Ш��P�[�J�ж����")]
    public InputField inputFieldCreateRoom;
    public InputField inpubtFieldJoinRoom;
    [Header("���a�����")]
    public NetworkPrefabRef goPlayer;
    [Header("�e���s�u")]
    public GameObject goCanvas;

    /// <summary>
    /// ���a��J�ж��W��
    /// </summary>
    private string roomNameInput;
    /// <summary>
    /// �s�u���澹
    /// </summary>
    private NetworkRunner runner;
    #endregion

    #region ��k
    /// <summary>
    /// ���s�I���I�s : �Ыةж�
    /// </summary>
    public void BtnCreateRoom()
    {
        roomNameInput = inputFieldCreateRoom.text;
        print("�Ыةж�: " + roomNameInput);
        StartGame(GameMode.Host); //�[�J�ж���Host
    }

    /// <summary>
    /// ���s�I���I�s: �[�J�ж�
    /// </summary>
    public void BtnJoinRoom()
    {
        roomNameInput = inpubtFieldJoinRoom.text;
        print("�[�J�ж�: " + roomNameInput);
        StartGame(GameMode.Client); //�[�J�ж���Client
    }

    //async �D�P�B�B�z: ����t�ήɳB�z�s�u
    /// <summary>
    /// �}�l�s�u�C��
    /// </summary>
    /// <param name="mode">�s�u�Ҧ�: �D���B�Ȥ�</param>
            //�P�B
    private async void StartGame(GameMode mode)
    {
        print("<color=yellow>�}�l�s�u </color>");

        runner = gameObject.AddComponent<NetworkRunner>(); //�s�u���澹  =�K�[����<�s�u���澹>
        runner.ProvideInput = true;                        //�s�u���澹.�O�_���ѿ�J = �O

        //���ݳs�u:�C���s�u�Ҧ��B�ж��W�١B�s�u�᪺�����B�����޲z��
        await runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomNameInput,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneObjectProvider = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
        print("<color=yellow>�s�u���� </color>");
        goCanvas.SetActive(false);
    }
    #endregion

    #region Fusion �^�I�禡�ϰ�
    public void OnConnectedToServer(NetworkRunner runner)
    {

    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {

    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }

    /// <summary>
    /// ���a���\�[�J�ж���
    /// </summary>
    /// <param name="runner">�s�u���澹</param>
    /// <param name="player">���a��T</param>
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        //�s�u����,�ͦ�(����B�y�СB���סB���a��T)
        runner.Spawn(goPlayer, new Vector3(-5, 0, -10), Quaternion.identity, player);
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {

    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
    #endregion
}
