using BrainStorm.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BrainStorm.Hubs
{
    public class ChatHub : Hub
    {
        public async Task NewMessage(ChatMessage msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}
