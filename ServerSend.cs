using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSServer
{
    internal class ServerSend
    {
        public static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.Clients[_toClient].tcp.SendData(_packet);
        }

        public static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.Clients[_toClient].udp.SendData(_packet);
        }

        public static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for(int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.Clients[i].tcp.SendData(_packet);
            }
        }
        public static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if(i != _exceptClient) Server.Clients[i].tcp.SendData(_packet);
            }
        }

        public static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.Clients[i].udp.SendData(_packet);
            }
        }
        public static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient) Server.Clients[i].udp.SendData(_packet);
            }
        }

        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }

        }

        public static void SpawnPlayer(int _toClient, Player _player)
        {
            using(Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);
                _packet.Write(_player.rotation);

                SendTCPData(_toClient,_packet);
            }
        }
    }
}
