using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace client
{
    public class Packet : IDisposable
    {
        public List<byte> buffer;
        private byte[] readableBuffer;
        private int readPos;
        
        public Packet()
        { //Builder that is only use as a buffer in the class client
            buffer = new List<byte>(); 
            readPos = 0;
        }
        public Packet(IdMsg id)
        {
            buffer = new List<byte>(); 
            readPos = 0;
            buffer.AddRange(BitConverter.GetBytes((int) id));
        }

        public Packet(byte[] _data)
        {
            buffer = new List<byte>(); 
            readPos = 0; 

            SetBytes(_data);
        }

        public void Reset(bool _shouldReset = true)
        {
            if (_shouldReset)
            {
                buffer.Clear();
                readableBuffer = null;
                readPos = 0; 
            }
            else
            {
                readPos -= 4; 
            }
        }

        public int UnreadLength()
        {
            return buffer.Count - readPos; 
        }
            
        public void SetBytes(byte[] _data)
        {
            foreach (byte i in _data)
            {
                buffer.Add(i);
            }
            readableBuffer = buffer.ToArray();
        }
            
        public int reste()
        {
            return buffer.Count - readPos;
        }
            

        public void Write(string _value)
        {
            buffer.AddRange(BitConverter.GetBytes(_value.Length));
            buffer.AddRange(Encoding.ASCII.GetBytes(_value)); 
        }

        public void Write(int _value)
        {
            buffer.AddRange(BitConverter.GetBytes(_value));
        }
            
        public int ReadInt(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                int _value = BitConverter.ToInt32(readableBuffer, readPos);
                if (_moveReadPos)
                {
                    readPos += 4;
                }
                return _value; 
            }
            else
            {
                Debug.Log($"Erreur fin msg : buffer:{buffer.Count}, pos: {readPos}");
                throw new Exception();
            }
        }
            
        public byte[] ReadBytes(int _length, bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                byte[] _value = buffer.GetRange(readPos, _length).ToArray(); 
                if (_moveReadPos)
                {
                    readPos += _length; 
                }
                return _value;
            }
            else
            {
                throw new Exception("Could not read value of type 'byte[]'!");
            }
        }

        public string ReadString(bool _moveReadPos = true)
        {
            try
            {
                int _length = ReadInt();
                string _value = Encoding.ASCII.GetString(readableBuffer, readPos, _length);
                if (_moveReadPos && _value.Length > 0)
                {
                    readPos += _length; 
                }
                return _value; 
            }
            catch
            {
                throw new Exception("Could not read value of type 'string'!");
            }
        }
            
        private bool disposed = false;
            
        protected virtual void Dispose(bool _disposing)
        {
            if (!disposed)
            {
                if (_disposing)
                {
                    buffer = null;
                    readableBuffer = null;
                    readPos = 0;
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}