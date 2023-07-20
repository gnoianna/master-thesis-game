using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class DataReceiver : MonoBehaviour
{

    private Thread receiveThread;
    private UdpClient client; 
    private int port = 5052;
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
        StartReceivingData();
    }

    private void StartReceivingData()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    public void StopReceiving()
    {
        if (client != null)
        {
            client.Close();
        }

        if (receiveThread != null)
        {
            receiveThread.Abort();
        }
    }

    private void ReceiveData()
    {

        client = new UdpClient(port);
        IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
        while (receiveThread.IsAlive)
        {
            try
            {
                byte[] dataByte = client.Receive(ref anyIP);
                Data = Encoding.UTF8.GetString(dataByte);
            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }

    public bool DataIsEmpty()
    {
        return Data.Length < 3;
    }

    private void OnApplicationQuit()
    {
        StopReceiving();
    }
}
