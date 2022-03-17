using System.Net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Server
{
    public class Server
    {
        public static int Port;
        public static int Max_players;
        public static TcpListener tcpListener;
        public static List<Client> clients;


        public static void Start()
        {
            Port = 27880;
            Max_players = 4;

            Console.Write("Start Server");
            clients = new List<Client>();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(NewClient, null);

            Console.WriteLine($"Server started on port {Port}.");
        }

        private static void NewClient(IAsyncResult _result)
        {
            TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
            tcpListener.BeginAcceptTcpClient(NewClient, null);
            Console.WriteLine($"New connection from {_client.Client.RemoteEndPoint}");

            if (clients.Count <= Max_players)
            {
                clients.Add(new Client(_client, clients.Count));
            }
            else
            {
                Console.WriteLine("Serveur full");
            }
        }
    }
}