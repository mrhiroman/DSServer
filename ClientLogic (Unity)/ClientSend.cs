﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.Instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.Instance.udp.SendData(_packet);
    }

    #region packets
    public static void WelcomeReceived()
    {
        using(Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.Instance.myId);
            _packet.Write(UIManager.Instance.usernameField.text);
            SendTCPData(_packet);
        }
    }
    #endregion
}
