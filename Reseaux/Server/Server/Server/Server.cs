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
        public static int countClient = 0;
        public static int countLobby = 0;
        public static Dictionary<int, Lobby.Lobby> lobbys;


        public static void Start()
        {
            Max_players = 10000000;

            Console.WriteLine("Start Server");
            clients = new Dictionary<int, Client>();
            lobbys = new Dictionary<int, Lobby.Lobby>();

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
                clients.Add(countClient, new Client(_client, countClient));
                clients[countClient].SendWelcome();
                Console.WriteLine($"New connection from {_client.Client.RemoteEndPoint}, with id: {countClient}");
                countClient++;
            }
            else
            {
                Console.WriteLine("Serveur full");
            }
        }
    }
}