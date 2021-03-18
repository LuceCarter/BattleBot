using BattleBot.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleBot.Services
{
    public class ChatService
    {
        private readonly IHubContext<ChatHub> _hub;
        public ChatService(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
    }
}
