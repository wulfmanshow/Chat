using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary.Models;
using System.Text.Json;

namespace ConsoleChatClient;

    public class ChatClient
    {
    private Socket _socket;
    private IPEndPoint _ipEndPoint;


    private Object? Send(IDataMessage message)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        _socket.Connect(_ipEndPoint);
        _socket.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message.ToMessage())));
        var Buffer = new byte[1024];
        int read = _socket.Receive(Buffer);
        _socket.Close();
        string incoming = Encoding.UTF8.GetString(Buffer, 0, read);
        var response = JsonSerializer.Deserialize<DataMessage>(incoming);
        switch (response.Type)
        {
            case DataType.RegisterResponce:
                return JsonSerializer.Deserialize<RegisterResponce>(response.Data);
            default:
                return null;

        }
    }


    public RegisterResponce Register(RegisterRequest registerRequest)
    {
        return Send(registerRequest) as RegisterResponce;
    }

    public ChatClient(string IpAddress, int port)
    {
        IPAddress ip = IPAddress.Parse(IpAddress);
        _ipEndPoint = new IPEndPoint(ip, port); // 5000 - port
        
    }
    


    //try
    //{
    //    do
    //    {
    //        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
    //    s.Connect(ep);
    //        Thread.Sleep(1000);
    //    } while (true);
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine(e.Message);
    //}

}
    

