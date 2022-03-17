using System;
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

            //TODO: send welcome

        }

        private void ReceiveData(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    // TODO: disconnect
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer, _data, _byteLength);

                receivedData.Reset(HandleData(_data));
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveData, null);
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error: {_ex}");
            }
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
            int _packetLength = 0;

            receivedData.SetBytes(_data);

            if (receivedData.reste() >= 4)
            {
                _packetLength = receivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    return true;
                }
            }

            while (_packetLength > 0 && _packetLength <= receivedData.reste())
            {
                byte[] _packetBytes = receivedData.ReadBytes(_packetLength);
                //TODO: handle the data

                _packetLength = 0;
                if (receivedData.reste() >= 4)
                {
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        return true;
                    }
                }
            }

            if (_packetLength <= 1)
            {
                return true;
            }

            return false;
        }

    }
}