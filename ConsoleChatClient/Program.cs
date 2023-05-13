

using ChatLibrary.Models;
using ConsoleChatClient;

var client = new ChatClient("127.0.0.1", 5000);
var request = new RegisterRequest()
{
    Name = "Nikita",
    Login = "Fanadei",
    Password = "SomePass",
};
var response = client.Register(request);
Console.WriteLine(response.Success);
Console.WriteLine(response.Error);
Console.WriteLine(response.User?.Id);
Console.WriteLine(response.User?.Name);
Console.WriteLine(response.User?.Login);

Console.ReadLine();