using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class PingPongDataExample : MonoBehaviour
{
    /// <summary>
    /// Simple TCP client
    /// </summary>
    private void Start()
    {
        try
        {
            //Connect to the server
            TcpClient client = new TcpClient("localhost", 1234); // Server IP and port

            //Translate the message into ASCII and store it as a byte array
            string message = "Hello from Unity Client";
            byte[] data = Encoding.ASCII.GetBytes(message);

            //Get a client stream for reading and writing
            NetworkStream stream = client.GetStream();

            //Send the message to the server
            stream.Write(data, 0, data.Length);
            Debug.Log("Sent: " + message);

            //Receive the response from the server (optional)
            data = new byte[256]; // Buffer to store the response bytes
            string responseData = String.Empty;
            int bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.ASCII.GetString(data, 0, bytes);
            Debug.Log("Received: " + responseData);

            //Close everything
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Debug.Log("ArgumentNullException: " + e);
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }
    }
}
