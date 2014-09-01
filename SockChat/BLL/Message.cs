using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SockChat.DAL;
using SockChat.Models;

namespace SockChat.BLL
{
    public class Message
    {
        public static List<MessageData> Get()
        {
            return Message.Get();
        }

        public static void Save(string name, string messageText, string channel)
        {
            DAL.Message.Save(name, messageText, channel);
        }
    }
}