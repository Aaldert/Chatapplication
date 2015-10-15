using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EindopdrachtServer
{
    class Client
    {
        TcpClient client;
        NetworkStream networkStream;
        public string username { get; private set; }
        private Thread _workerThread;

        public Client(TcpClient socket)
        {
            client = socket;
            networkStream = client.GetStream();
            Console.WriteLine("Nieuwe client connected");
            _workerThread = new Thread(recieve);
            _workerThread.Start();
        }

        public void recieve()
        {
            while (!(client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0))
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
                String response = Encoding.ASCII.GetString(bytesFrom);
                String[] response_parts = response.Split('|');
                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //login
                            if (response_parts[1]!= null)
                            {
                                username = response_parts[1];
                                Console.WriteLine(username);
                                sendString("1|" + username + "|");
                            }
                            break;

                        case "2":
                            if (response_parts[2] != null)
                            {
                                String message = response_parts[2];
                                String sender = response_parts[1];

                                sendString("3|" + sender + "|" + message);
                                foreach (var gebruiker in Program.Gebruikers)
                                {
                                    if(gebruiker.username != sender)
                                    {
                                        gebruiker.sendString("3|" + sender + "|" + message);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            Stop();
        }

        private void Stop()
        {
            Program.verweiderGebruikersUitLijst(this);
            _workerThread.Abort();
        }

        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            networkStream.Write(b, 0, b.Length);
            networkStream.Flush();
        }
    }
}
