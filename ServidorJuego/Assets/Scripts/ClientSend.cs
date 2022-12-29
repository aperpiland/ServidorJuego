using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClientSend : MonoBehaviour
{
    //Igual que en el servidor, solo que en este caso no hace falta decir a que cliente se le envía, porque solo hay un server
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    //1 Creamos La clase SendUDPData con el tamaño del paquete
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets

    // de igual forma creamos el método WelcomeReceived que se encarga de enviar un mensaje de tipo Welcome
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            //string aux = "test";
            _packet.Write(Client.instance.myId);

            //_packet.Write(aux);
           
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
            SceneManager.LoadScene(1);

        }
        //datos();
    }

    
     public static void datos()
    {
        using (Packet _packet = new Packet((int)ClientPackets.datos))
        {
            _packet.Write(UIManager.instance.n1v);
            _packet.Write(UIManager.instance.n2v);

            SendTCPData(_packet);
        }
    }

    public static void dado(int turno)
    {
        using (Packet _packet = new Packet((int)ClientPackets.dadoRecieved))
        {
            _packet.Write(turno);
            SendTCPData(_packet);
        }
    }
    #endregion Packets
   
}