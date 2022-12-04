using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSServer
{
    internal class ServerHandler
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();
            Console.WriteLine($"{Server.Clients[_fromClient].tcp.socket.Client.RemoteEndPoint} has successfully connected and is now player {_fromClient} (nickname: {_username})");

            if(_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player {_username}(ID: {_fromClient} is accusing to have wrong Client ID {_clientIdCheck}");
            }

            Server.Clients[_fromClient].SendIntoGame(_username);
        }


    }
}
