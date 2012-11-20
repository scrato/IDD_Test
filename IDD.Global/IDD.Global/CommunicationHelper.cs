using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global
{
    public static class CommunicationHelper
    {
        private static UTF8Encoding enc= new UTF8Encoding();



        public static byte[] createPaket(byte[] content, int messageType, int id)
        {

            //Command
            byte[] command = BitConverter.GetBytes(messageType);
            List<byte> array = fillListWithByteArray(new List<byte>(), checklenght(command, 10));

            //Länge des Contents
            array = fillListWithByteArray(array, checklenght(BitConverter.GetBytes(content.Length), 255));

            //Content
            array = fillListWithByteArray(array, content);

            //IdBit
            byte[] idBits = BitConverter.GetBytes(id);
            array = fillListWithByteArray(array, checklenght(idBits, 5));

            return array.ToArray();
        }


    
        public static int checkMessageType(Socket socket)
        {
            byte[] msgtype = new byte[10];
            socket.Receive(msgtype, 10, SocketFlags.None);

            if (msgtype.Length == 0) return -1;

            return BitConverter.ToInt32(msgtype, 0);
        }
        public static byte[] checkMessageContent(Socket socket)
        {
            byte[] content = null;
            byte[] length = new byte[255];
            socket.Receive(length, 255, SocketFlags.None);

            int reallength = BitConverter.ToInt32(length, 0);
            if (reallength > 0)
            {
                int contentLength = BitConverter.ToInt32(length, 0);
                content = new byte[contentLength];
                socket.Receive(content, contentLength, SocketFlags.None);
            }
            return content;
        }
        public static int checkMessageId(Socket socket)
        {
            byte[] id = new byte[5];
            socket.Receive(id, 5, SocketFlags.None);
           
            return BitConverter.ToInt32(id,0);
        }
        private static byte[] checklenght(byte[] length, int p)
        {
            if (length.Length < p)
            {
                byte[] newlength = new byte[p];
                for (int i = 0; i < length.Length; i++)
                {
                    newlength[i] = length[i];
                }
                return newlength;
            }

            if (length.Length > p)
            {
                throw new NotImplementedException();
            }

            return length;
        }
        private static  List<byte> fillListWithByteArray(List<Byte> list, byte[] array)
        {
            foreach (byte element in array)
            {
                list.Add(element);
            }
            return list;
        }




        public static string DecodeString(byte[] content)
        {
            lock (enc)
            { 
                return enc.GetString(content);
            }
        }

        public static byte[] EncodeString(string content)
        {
            lock (enc)
            {
                return enc.GetBytes(content);
            }
        }
    }
}
