using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviarClick : MonoBehaviour
{
    public static EnviarClick instance;

    public int turno = 0;

    private void Start()
    {
        //Client.instance.ConnectToServer();
    }

    private void OnMouseDown()
    {
        turno++;
        ClientSend.dado(turno);
    }
}
