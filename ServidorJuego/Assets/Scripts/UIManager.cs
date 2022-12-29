using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //1
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;

    public InputField numero1Input;
    public InputField numero2Input;

    public int n1v;
    public int n2v;

    

    //1 asegurarnos de que no hay más de una instancia de Client en el juego
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //2 Para clicar el botón
    public void ConnectToServer()
    {
        //startMenu.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }
    public void numeros()
    {
        n1v = int.Parse(numero1Input.text);
        n2v = int.Parse(numero2Input.text);
        Client.instance.ConnectToServer();
    }

   


}
