using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;


namespace Network
{
    public class Client : MonoBehaviour
    {
        public static Client instance;
        public static int dataBufferSize = 4096;

        public string ip = "127.0.0.1";
        public int port = 26950;
        public int myId = 0;

        public TcpClient socket;
        public static bool isConnected = false;
        private delegate void PacketHandler(Packet _packet);

        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            ConnectToServer();
        }
        
        public void ConnectToServer()
        {
            Debug.Log("A");
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
            socket.Close();
            stream = null;
            receivedData = null;
            receiveBuffer = null;
            socket = null;
            isConnected = false;
        }

        private void ConnectCallback(IAsyncResult _result)
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

        private void ReceiveCallback(IAsyncResult _result)
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
                this.Disconnect(); 
            }
        }

        private bool HandleData(byte[] _data)
        {
            receivedData.SetBytes(_data);
            /*
            if (receivedData.UnreadLength() >= 4)
            {
                _packetLength = receivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    return true;
                }
            }*/
            
            int _packetId = this.receivedData.ReadInt();
            ClientHandle.ClientActions(this.receivedData,(IdMsg) _packetId);

                
            /*

            if (_packetLength <= 1)
            {
                return true;
            }*/

            return true;
        }
    }
}

