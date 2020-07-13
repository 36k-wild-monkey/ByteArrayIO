using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ByteArrayIO
{
    public class ByteArray : IDisposable
    {
        MemoryStream stream = null;
        public long Position
        {
            get
            {
                return stream.Position;
            }
            set
            {
                stream.Position = value;
            }
        }
        public long Length
        {
            get
            {
                return stream.Length;
            }
        }
        public bool CanRead
        {
            get
            {
                return stream.CanRead;
            }
        }
        public bool CanWrite
        {
            get
            {
                return stream.CanWrite;
            }
        }
        public bool CanSeek
        {
            get
            {
                return stream.CanSeek;
            }
        }
        /// <summary>
        /// Create an empty read and write stream
        /// </summary>
        public ByteArray()
        {
            stream = new MemoryStream();
        }
        /// <summary>
        /// Create a read-write stream from data
        /// </summary>
        /// <param name="data"></param>
        public ByteArray(byte[] data)
        {
            stream = new MemoryStream();
            Write(data);
            stream.Position = 0;
        }
        private ByteArray Write(byte[] data)
        {
            stream.Write(data, 0, data.Length);
            return this;
        }
        private ByteArray Write(byte[] data, int length)
        {
            stream.Write(data, 0, length);
            return this;
        }
        private byte[] Read(int length)
        {
            if (length < 1)
            {
                return new byte[0];
            }
            else
            {
                var buf = new byte[length];
                stream.Read(buf, 0, buf.Length);
                return buf;
            }
        }
        private ByteArray WriteMode(byte[] val, bool IsLittleEndian = true)
        {
            if (BitConverter.IsLittleEndian == IsLittleEndian)
            {
                return this.Write(val);
            }
            else
            {
                return this.Write(val.Reverse().ToArray());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 1 byte to the data stream</param>
        public ByteArray WriteByte(Byte val)
        {
            return WriteUInt8(val);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 1 byte to the data stream</param>
        public ByteArray WriteInt8(SByte val)
        {
            return Write(new byte[1] { (byte)val }, sizeof(SByte));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 1 byte to the data stream</param>
        public ByteArray WriteUInt8(Byte val)
        {
            return Write(new byte[1] { (byte)val }, sizeof(Byte));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 2 byte of little endian to the data stream</param>
        public ByteArray WriteInt16LE(Int16 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 2 byte of big endian to the data stream</param>
        public ByteArray WriteInt16BE(Int16 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 2 byte of little endian to the data stream</param>
        public ByteArray WriteUInt16LE(UInt16 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 2 byte of big endian to the data stream</param>
        public ByteArray WriteUInt16BE(UInt16 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of little endian to the data stream</param>
        public ByteArray WriteInt32LE(Int32 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of big endian to the data stream</param>
        public ByteArray WriteInt32BE(Int32 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of little endian to the data stream</param>
        public ByteArray WriteUInt32LE(UInt32 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of big endian to the data stream</param>
        public ByteArray WriteUInt32BE(UInt32 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of little endian to the data stream</param>
        public ByteArray WriteInt64LE(Int64 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of big endian to the data stream</param>
        public ByteArray WriteInt64BE(Int64 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of little endian to the data stream</param>
        public ByteArray WriteUInt64LE(UInt64 val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of big endian to the data stream</param>
        public ByteArray WriteUInt64BE(UInt64 val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of little endian to the data stream</param>
        public ByteArray WriteFloatLE(float val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 4 byte of big endian to the data stream</param>
        public ByteArray WriteFloatBE(float val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of little endian to the data stream</param>
        public ByteArray WriteDoubleLE(double val)
        {
            return WriteMode(BitConverter.GetBytes(val), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write a 8 byte of big endian to the data stream</param>
        public ByteArray WriteDoubleBE(double val)
        {
            return WriteMode(BitConverter.GetBytes(val), false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write utf8 text data</param>
        /// <param name="length">Write the specified length text otherwise write to the current text and insert it at \x00.</param>
        public ByteArray WriteString(string val, int length = -1)
        {
            if (length < 0)
            {
                var data = Encoding.UTF8.GetBytes(val);
                return Write(data).WriteByte(0);
            }
            else
            {
                var data = Encoding.UTF8.GetBytes(val.Substring(0, length));
                return Write(data);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Write byte array data</param>
        /// <param name="length">Write the specified length otherwise write the length of the current data.</param>
        public ByteArray WriteBytes(byte[] val, int length = -1)
        {
            if (length < 0)
            {
                return Write(val);
            }
            else
            {

                return Write(val, length);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to Byte</returns>
        public Byte ReadByte()
        {
            return ReadUInt8();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to Byte</returns>
        public ByteArray ReadByte(Action<Byte> action)
        {
            action(ReadByte());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to Int8</returns>
        public SByte ReadInt8()
        {
            int size = sizeof(SByte);
            byte[] buf = Read(size);
            if (buf.Length > 0)
            {
                return (SByte)buf[0];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to Int8</returns>
        public ByteArray ReadInt8(Action<SByte> action)
        {
            action(ReadInt8());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to UInt8</returns>
        public Byte ReadUInt8()
        {
            int size = sizeof(Byte);
            byte[] buf = Read(size);
            if (buf.Length > 0)
            {
                return (Byte)buf[0];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 1 byte data to UInt8</returns>
        public ByteArray ReadUInt8(Action<Byte> action)
        {
            action(ReadUInt8());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of little endian to Int16</returns>
        public Int16 ReadInt16LE()
        {
            int size = sizeof(Int16);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (Int16)BitConverter.ToInt16(buf, 0);
            }
            else
            {
                return (Int16)BitConverter.ToInt16(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of little endian to Int16</returns>
        public ByteArray ReadInt16LE(Action<Int16> action)
        {
            action(ReadInt16LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of big endian to Int16</returns>
        public Int16 ReadInt16BE()
        {
            int size = sizeof(Int16);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (Int16)BitConverter.ToInt16(buf, 0);
            }
            else
            {
                return (Int16)BitConverter.ToInt16(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of big endian to Int16</returns>
        public ByteArray ReadInt16BE(Action<Int16> action)
        {
            action(ReadInt16BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of little endian to UInt16</returns>
        public UInt16 ReadUInt16LE()
        {
            int size = sizeof(UInt16);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (UInt16)BitConverter.ToUInt16(buf, 0);
            }
            else
            {
                return (UInt16)BitConverter.ToUInt16(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of little endian to UInt16</returns>
        public ByteArray ReadUInt16LE(Action<UInt16> action)
        {
            action(ReadUInt16LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of big endian to UInt16</returns>
        public UInt16 ReadUInt16BE()
        {
            int size = sizeof(UInt16);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (UInt16)BitConverter.ToUInt16(buf, 0);
            }
            else
            {
                return (UInt16)BitConverter.ToUInt16(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 2 byte data of big endian to UInt16</returns>
        public ByteArray ReadUInt16BE(Action<UInt16> action)
        {
            action(ReadUInt16BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to Int32</returns>
        public Int32 ReadInt32LE()
        {
            int size = sizeof(Int32);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (Int32)BitConverter.ToInt32(buf, 0);
            }
            else
            {
                return (Int32)BitConverter.ToInt32(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to Int32</returns>
        public ByteArray ReadInt32LE(Action<Int32> action)
        {
            action(ReadInt32LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to Int32</returns>
        public Int32 ReadInt32BE()
        {
            int size = sizeof(Int32);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (Int32)BitConverter.ToInt32(buf, 0);
            }
            else
            {
                return (Int32)BitConverter.ToInt32(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to Int32</returns>
        public ByteArray ReadInt32BE(Action<Int32> action)
        {
            action(ReadInt32BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to UInt32</returns>
        public UInt32 ReadUInt32LE()
        {
            int size = sizeof(UInt32);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (UInt32)BitConverter.ToUInt32(buf, 0);
            }
            else
            {
                return (UInt32)BitConverter.ToUInt32(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to UInt32</returns>
        public ByteArray ReadUInt32LE(Action<UInt32> action)
        {
            action(ReadUInt32LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to UInt32</returns>
        public UInt32 ReadUInt32BE()
        {
            int size = sizeof(UInt32);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (UInt32)BitConverter.ToUInt32(buf, 0);
            }
            else
            {
                return (UInt32)BitConverter.ToUInt32(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to UInt32</returns>
        public ByteArray ReadUInt32BE(Action<UInt32> action)
        {
            action(ReadUInt32BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to Int64</returns>
        public Int64 ReadInt64LE()
        {
            int size = sizeof(Int64);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (Int64)BitConverter.ToInt64(buf, 0);
            }
            else
            {
                return (Int64)BitConverter.ToInt64(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to Int64</returns>
        public ByteArray ReadInt64LE(Action<Int64> action)
        {
            action(ReadInt64LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to Int64</returns>
        public Int64 ReadInt64BE()
        {
            int size = sizeof(Int64);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (Int64)BitConverter.ToInt64(buf, 0);
            }
            else
            {
                return (Int64)BitConverter.ToInt64(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to Int64</returns>
        public ByteArray ReadInt64BE(Action<Int64> action)
        {
            action(ReadInt64BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to UInt64</returns>
        public UInt64 ReadUInt64LE()
        {
            int size = sizeof(UInt64);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (UInt64)BitConverter.ToUInt64(buf, 0);
            }
            else
            {
                return (UInt64)BitConverter.ToUInt64(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to UInt64</returns>
        public ByteArray ReadUInt64LE(Action<UInt64> action)
        {
            action(ReadUInt64LE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to UInt64</returns>
        public UInt64 ReadUInt64BE()
        {
            int size = sizeof(UInt64);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (UInt64)BitConverter.ToUInt64(buf, 0);
            }
            else
            {
                return (UInt64)BitConverter.ToUInt64(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to UInt64</returns>
        public ByteArray ReadUInt64BE(Action<UInt64> action)
        {
            action(ReadUInt64BE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to Float</returns>
        public float ReadFloatLE()
        {
            int size = sizeof(float);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (float)BitConverter.ToSingle(buf, 0);
            }
            else
            {
                return (float)BitConverter.ToSingle(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of little endian to Float</returns>
        public ByteArray ReadFloatLE(Action<float> action)
        {
            action(ReadFloatLE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to Float</returns>
        public float ReadFloatBE()
        {
            int size = sizeof(float);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (float)BitConverter.ToSingle(buf, 0);
            }
            else
            {
                return (float)BitConverter.ToSingle(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 4 byte data of big endian to Float</returns>
        public ByteArray ReadFloatBE(Action<float> action)
        {
            action(ReadFloatBE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to Double</returns>
        public double ReadDoubleLE()
        {
            int size = sizeof(double);
            byte[] buf = Read(size);
            if (BitConverter.IsLittleEndian)
            {
                return (double)BitConverter.ToDouble(buf, 0);
            }
            else
            {
                return (double)BitConverter.ToDouble(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of little endian to Double</returns>
        public ByteArray ReadDoubleLE(Action<double> action)
        {
            action(ReadDoubleLE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to Double</returns>
        public double ReadDoubleBE()
        {
            int size = sizeof(double);
            byte[] buf = Read(size);
            if (!BitConverter.IsLittleEndian)
            {
                return (double)BitConverter.ToDouble(buf, 0);
            }
            else
            {
                return (double)BitConverter.ToDouble(buf.Reverse().ToArray(), 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Read 8 byte data of big endian to Double</returns>
        public ByteArray ReadDoubleBE(Action<double> action)
        {
            action(ReadDoubleBE());
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length text if the length is -1 and read to the end of the \x00.</param>
        /// <returns>Read the specified length utf8 text</returns>
        public string ReadString(int length = -1)
        {
            if (length > 0)
            {
                byte[] buf = Read(length);
                return Encoding.UTF8.GetString(buf);
            }
            else
            {
                long pos = stream.Position;
                length = 0;
                int i = 0;
                while (stream.Position < stream.Length)
                {
                    i = stream.ReadByte();
                    length += 1;
                    if (i == 0)
                    {
                        break;
                    }
                }
                if (i == 0)
                {
                    length -= 1;
                    if (length < 0)
                    {
                        length = 0;
                    }
                }
                stream.Position = pos;
                byte[] buf = Read(length);

                // skip \x00
                Seek(1, SeekOrigin.Current);
                return Encoding.UTF8.GetString(buf);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length text if the length is -1 and read to the end of the \x00.</param>
        /// <returns>Read the specified length utf8 text</returns>
        public ByteArray ReadString(Action<string> action)
        {
            action(ReadString(-1));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length text if the length is -1 and read to the end of the \x00.</param>
        /// <returns>Read the specified length utf8 text</returns>
        public ByteArray ReadString(int length, Action<string> action)
        {
            action(ReadString(length));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length of the bytes if the length is -1 to read to the end</param>
        /// <returns>Read the specified length of the bytes</returns>
        public byte[] ReadBytes(int length = -1)
        {
            if (length < 0)
            {
                length = (int)(stream.Length - stream.Position);
                if (length < 0)
                {
                    length = 0;
                }
            }
            byte[] buf = Read(length);
            return buf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length of the bytes if the length is -1 to read to the end</param>
        /// <returns>Read the specified length of the bytes</returns>
        public ByteArray ReadBytes(Action<byte[]> action)
        {
            action(ReadBytes(-1));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">Read the specified length of the bytes if the length is -1 to read to the end</param>
        /// <returns>Read the specified length of the bytes</returns>
        public ByteArray ReadBytes(int length, Action<byte[]> action)
        {
            action(ReadBytes(length));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Pack the data in the current stream</returns>
        public byte[] ToArray()
        {
            return stream.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">The new position within the stream. This is relative to the loc parameter, and can be positive or negative.</param>
        /// <param name="loc">A value of type System.IO.SeekOrigin, which acts as the seek reference point.</param>
        /// <returns></returns>
        public ByteArray Seek(long offset, SeekOrigin loc)
        {
            stream.Seek(offset, loc);
            return this;
        }
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream.
        /// </summary>
        /// <param name="stream">The stream to which the contents of the current stream will be copied.</param>
        public ByteArray CopyTo(Stream stream)
        {
            this.stream.CopyTo(stream);
            return this;
        }
        /// <summary>
        /// Sets the length of the current stream to the specified value.
        /// </summary>
        /// <param name="value">The value at which to set the length.</param>
        public ByteArray SetLength(long value)
        {
            stream.SetLength(value);
            return this;
        }
        /// <summary>
        /// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream. Instead of calling this method,ensure that the stream is properly disposed.
        /// </summary>
        public void Close()
        {
            stream.Close();
        }
        /// <summary>
        /// Releases all resources used by the System.IO.Stream.
        /// </summary>
        public void Dispose()
        {
            stream.Dispose();
        }

    }
}