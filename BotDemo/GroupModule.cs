using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace BotDemo
{
    public class GroupModule : IModule
    {
        public bool? IsEnable { get; set; }
        public async void Execute(MessageReceiverBase receiver)
        {
            if (receiver is not GroupMessageReceiver e) return;
            if (!e.MessageChain.GetPlainMessage().StartsWith("/fuckyou")) return;
            var res = epic.GetEpicGame();
            await e.SendMessageAsync(res);
        }
    }
}
