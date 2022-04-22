using System;
using System.ComponentModel.Design.Serialization;
using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        public int Id;
        public int dataBufferSize = 4096;
        public TcpClient socket;
        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;

        public Client(TcpClient _socket, int id)
        {
            Id = id;
            socket = _socket;
            socket.ReceiveBufferSize = dataBufferSize;
            socket.SendBufferSize = dataBufferSize;

            stream = socket.GetStream();

            receivedData = new Packet();
            receiveBuffer = new byte[dataBufferSize];

            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveData, null);

        }

        private void ReceiveData(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    this.Disconnect();
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer, _data, _byteLength);

                receivedData.Reset(HandleData(_data));
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveData, null);
            }
            catch (Exception _ex)
            {
                this.Disconnect();
                Console.WriteLine($"Error: {_ex}");
            }
        }
        
        public void Disconnect()
        {
            socket.Close();
            stream = null;
            receivedData = null;
            receiveBuffer = null;
            socket = null;
        }

        public void SendWelcome()
        {
            Send.SendWelcome(this.Id);
        }

        public void SendData(Packet _packet)
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
                Console.WriteLine($"Error sending data to player {Id} via TCP: {_ex}");
            }
        }

        private bool HandleData(byte[] _data)
        {
            receivedData.SetBytes(_data);
            int _packetId = this.receivedData.ReadInt();
            ServerHandle.ServerActions(this.receivedData,(IdMsg) _packetId);
            return true;
        }

    }
}