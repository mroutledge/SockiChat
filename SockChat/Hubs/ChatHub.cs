using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SockChat.BLL;

namespace SockChat.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string channelName) 
        {
            Message.Save(name, message, channelName);
            Clients.All.broadcastMessage(name, message);
        }
    }
}