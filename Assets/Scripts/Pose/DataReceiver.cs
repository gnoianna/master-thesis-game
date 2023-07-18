using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class DataReceiver : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client; 
    public int port = 5052;
    public string Data;

    public static DataReceiver Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {

        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                Data = Encoding.UTF8.GetString(dataByte);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    public bool DataIsEmpty()
    {
        return Data == "[]";
      
    }

    private void OnApplicationQuit()
    {
        client.Close();
        receiveThread.Abort();
    }

}
