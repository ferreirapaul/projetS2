using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Sockets;
using Game;
using System;


namespace Network
{
    public class Client : MonoBehaviour
    {
        public static Client instance;
        public static int dataBufferSize = 4096;

        public string ip = "127.0.0.1";
        public int port = 27880;
        public int myId = 0;

        public TcpClient socket;
        public bool isConnected = false;

        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;

        public LobbyInfos lobby;
        public Game.Game game;

        public void Awake()
        {
            lobby = FindObjectOfType<LobbyInfos>();
            
            if (instance == null)
            {
                instance = this;
            }
            ConnectToServer();
        }

        public void Update()
        {
            if (lobby is null && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
            {
                game = FindObjectOfType<Game.Game>();
            }
        }

        public void ConnectToServer()
        {
            socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
            };

            receiveBuffer = new byte[dataBufferSize];
            socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
        }
        
        public void Disconnect()
        {
            Debug.Log("Disconnect ;(");
            socket.Close();
            stream = null;
            receivedData = null;
            receiveBuffer = null;
            socket = null;
            isConnected = false;
        }

        public void ConnectCallback(IAsyncResult _result)
        {
            socket.EndConnect(_result);

            if (!socket.Connected)
            {
                return;
            }

            stream = socket.GetStream();

            receivedData = new Packet();

            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }

        public void SendClientData(Packet _packet)
        {
            try
            {
                if (socket != null)
                {
                    stream.BeginWrite(_packet.buffer.ToArray(), 0, _packet.buffer.Count, null, null);
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error sending data to server via TCP: {_ex}");
            }
        }

        public void ReceiveCallback(IAsyncResult _result)
        {
            try
            {
                Debug.Log("Received !");
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    this.Disconnect();
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer, _data, _byteLength);

                receivedData.Reset(HandleData(_data));
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch
            {
                //this.Disconnect(); 
            }
        }

        public bool HandleData(byte[] _data)
        {
            ClientHandle handle = new ClientHandle(this);
            receivedData.SetBytes(_data);
            int _packetId = this.receivedData.ReadInt();
            handle.ClientActions(this.receivedData,(IdMsg) _packetId);
            return true;
        }
    }
}

