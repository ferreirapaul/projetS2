using System.Net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Server
{
    public class Server
    {
        public static int Port = 27880;
        public static int Max_players;
        public static TcpListener tcpListener;
        public static Dictionary<int, Client> clients;
        public static int count = 0;


        public static void Start()
        {
            Max_players = 4;

            Console.WriteLine("Start Server");
            clients = new Dictionary<int, Client>();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(NewClient, null);

            Console.WriteLine($"Server started on port {Port}.");
        }

        private static void NewClient(IAsyncResult _result)
        {
            TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
            tcpListener.BeginAcceptTcpClient(NewClient, null);
            

            if (clients.Count <= Max_players)
            {
                clients.Add(count, new Client(_client, count));
                clients[count].SendWelcome();
                Console.WriteLine($"New connection from {_client.Client.RemoteEndPoint}, with id: {count}");
                count++;
            }
            else
            {
                Console.WriteLine("Serveur full");
            }
        }
    }
}