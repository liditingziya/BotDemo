// using BotDemo;
// using Mirai.Net.Data.Messages.Receivers;
// using Mirai.Net.Sessions;
// using System.Reactive.Linq;
// using Mirai.Net.Utils.Scaffolds;
//
// var exit = new ManualResetEvent(false);
//
// using var bot = new MiraiBot
// {
//     Address = "127.0.0.1:8080",
//     VerifyKey = "ZHANG1131",
//     QQ = "2594966023"
// };
//
// await bot.LaunchAsync();
//
// Console.WriteLine("Mirai Bot开始运行----------");
//
// GroupModule Gmoudles=new GroupModule();
// bot.MessageReceived.OfType<GroupMessageReceiver>().Subscribe(x =>
// {
//     Gmoudles.Execute(x);
// });
// bot.MessageReceived.OfType<FriendMessageReceiver>().Subscribe(x =>
// {
//     var res = epic.GetEpicGame();
//     x.SendMessageAsync(res.Substring(0, 20));
// });
// exit.WaitOne();

using System.Net;
using Discord;
using Discord.Net.Rest;
using Discord.Net.WebSockets;
using Discord.Rest;
using Discord.WebSocket;

namespace BotDemo;

public class Program
{
    private DiscordRestClient _client;
	
    public static Task Main(string[] args) => new Program().MainAsync();

    public async Task MainAsync()
    {
        var config = new DiscordRestConfig // or DiscordSocketConfig, if using a Socket client
        {
            RestClientProvider = DefaultRestClientProvider.Create(useProxy: true)
        };
        // var config = new DiscordSocketConfig // or DiscordSocketConfig, if using a Socket client
        // {
        //     WebSocketProvider = DefaultWebSocketProvider.Create(new WebProxy("127.0.0.1:10809"))
        // };
        _client = new DiscordRestClient(config);
        _client.Log += Log;
        await _client.LoginAsync(TokenType.Bot, 
            "MTA2OTYwNjI1MDk1MTc0OTc2Mw.GOggiE.MepWZflMHoqW6Yz-7levzyL1Y5X9wvl9VCx8Zg");

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}


// public class Program
// {
//     
//     private DiscordSocketClient _client;
//
//     
//     public static Task Main(string[] args) => new Program().MainAsync();
//
//     private async Task MainAsync()
//     {
//         _client = new DiscordSocketClient();
//
//         _client.Log += Log;
//
//         //  You can assign your bot token to a string, and pass that in to connect.
//         //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
//         const string token = "MTA2OTYwNjI1MDk1MTc0OTc2Mw.GOggiE.MepWZflMHoqW6Yz-7levzyL1Y5X9wvl9VCx8Zg";
//
//         // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
//         // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
//         // var token = File.ReadAllText("token.txt");
//         // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;
//
//         await _client.LoginAsync(TokenType.Bot, token);
//         await _client.StartAsync();
//         // Block this task until the program is closed.
//         await Task.Delay(-1);
//     }
//     
//     private static Task Log(LogMessage msg)
//     {
//         Console.WriteLine(msg.ToString());
//         return Task.CompletedTask;
//     }
// }

