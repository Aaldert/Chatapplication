using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class TcpConnection
    {
        public TcpClient client;
        public bool isConnectedFlag { private set; get; }
        private NetworkStream serverStream;
        public string Gebruiker { private set; get; }
        private Thread receiveThread;

        public delegate void ChatmassegeDelegate(string[] data);
        public event ChatmassegeDelegate IncomingChatmessageEvent;

        public TcpConnection()
        {
            client = new TcpClient();
            connect();
        }

        private void onIncomingChatMessage(string[] data)
        {
            ChatmassegeDelegate cMD = IncomingChatmessageEvent;
            if (cMD != null)
            {
                cMD(data);
            }
        }

        public bool isConnected()
        {
            return isConnectedFlag;
        }

        public void connect()
        {
            try
            {
                client.Connect(Dns.GetHostAddresses(Dns.GetHostName()), 1288);

                // create streams
                serverStream = client.GetStream();
                receiveThread = new Thread(receive);
                receiveThread.Start();
                isConnectedFlag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Thread.Sleep(1000);
                isConnectedFlag = false;
            }
        }

        public void disconnect()
        {
            receiveThread.Abort();
            serverStream.Close();
            client.Close();
            isConnectedFlag = false;
        }

        public void receive()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                serverStream.Read(bytesFrom, 0, client.ReceiveBufferSize);
                string response = Encoding.ASCII.GetString(bytesFrom);
                string[] response_parts = response.Split('|');

                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "1":   //login and display correct window after login
                            string[] data1 = { response_parts[1] };
                            break;

                        case "3":
                            //                  sender              receiver            message
                            string[] data2 = { response_parts[1], response_parts[2], response_parts[3] };

                            onIncomingChatMessage(data2);
                            break;
                    }
                }
            }
        }

        public void SendUsername(string username)
        {
            // send command ( cmdID | username)
            this.Gebruiker = username;
            SendString("0|" + username + "|");
        }

        public void SendChatMessage(string[] data)
        {
            String bericht = data[0];

            // send command ( cmdID | username sender | message )
            string protocol = "2|" + this.Gebruiker + "|" + bericht;
            SendString(protocol);

        }

        public void SendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }
    }
}
