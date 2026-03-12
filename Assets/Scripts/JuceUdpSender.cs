using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class JuceUdpSender : MonoBehaviour
{
    public string host = "127.0.0.1";
    public int port = 9001;

    private UdpClient client;

    void Start()
    {
        client = new UdpClient();
    }

    public void SendNoteOn(int midiNote, float velocity = 1.0f)
    {
        SendMessageToJuce($"noteon,{midiNote},{velocity}");
    }

    public void SendNoteOff(int midiNote)
    {
        SendMessageToJuce($"noteoff,{midiNote}");
    }

    void SendMessageToJuce(string message)
    {
        if (client == null)
            return;

        byte[] data = Encoding.UTF8.GetBytes(message);
        client.Send(data, data.Length, host, port);
    }

    void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Close();
            client = null;
        }
    }
}