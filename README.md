# UnityBoostAsioExample
1. Download and install CMake: https://cmake.org/download/
2. Download and install Boost https://www.boost.org/users/history/ - v1.84.0 is used in this example
3. Prepare CMakeList.txt - project name "SimpleExample" , targeting simple_example.cpp to be built
4. run the build.bat, it will create "build\Debug" folder with the exe for the server
5. Sample Unity script which connects to the server:

```csharp
using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class TcpClientSample : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] buffer = new byte[1024];

    void Start()
    {
        client = new TcpClient("localhost", 8888);
        stream = client.GetStream();
        stream.BeginRead(buffer, 0, buffer.Length, OnRead, null);
    }

    private void OnRead(IAsyncResult ar)
    {
        int receivedBytes = stream.EndRead(ar);

        if (receivedBytes > 0)
        {
            string receivedString = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            Debug.Log("Received from server: " + receivedString);

            // Continue reading from the stream asynchronously
            stream.BeginRead(buffer, 0, buffer.Length, OnRead, null);
        }
        else
            Debug.Log("Disconnected from server");
    }
}

