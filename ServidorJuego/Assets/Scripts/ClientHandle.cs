using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
     public static void Welcome(Packet _packet)
     {
         //Lo tenemos que recibir en el mismo orden que lo hemos enviado en el servidor
         string _msg = _packet.ReadString();
         int _myId = _packet.ReadInt();

         Debug.Log($"Message from server: {_msg}");
         Client.instance.myId = _myId;

         //Responder al servidor
         ClientSend.WelcomeReceived();

         //1 Inicializamos la conexión UDP al servidor una vez nos hemos conectado por TCP
         Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
        
    }

    public static void RandomNumberReceived(Packet _packet)
    {
        int num = _packet.ReadInt();
        Dice.instance.RollTheDice(num);
        Debug.Log($"El dado aleatorio es {num+1}");
    }
}