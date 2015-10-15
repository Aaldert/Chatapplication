using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtServer
{
    class Program
    {
        public static List<Client> Gebruikers { get; private set; } = new List<Client>();
        static void Main(string[] args)
        {
            Console.WriteLine("Server wordt gestart.");
            TcpListener serverSocket = new TcpListener(1288);
            serverSocket.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients..");
                Gebruikers.Add(new Client(serverSocket.AcceptTcpClient()));
            }

            serverSocket.Stop();
            Console.WriteLine("Server afsluiten");
        }

        public static void verweiderGebruikersUitLijst(Client client)
        {
            string s = "Username " + client.username + " has been disconnected.";
            Gebruikers.Remove(client);
            Console.WriteLine(s);
        }
    }
}
