using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SockChat.Models;
using System.Data.Entity;

namespace SockChat.DAL
{
    public class Message
    {
        /// <summary>
        /// Get top messages
        /// </summary>
        public static List<MessageData> Get()
        {
            List<MessageData> messages = new List<MessageData>();

            using (var context = new ApplicationDbContext())
            {
                messages = context.Messages.Include( p => p.User).ToList();
            }

            return messages;
        }

        public static void Save(string name, string text, string channel)
        {
            MessageData md = new MessageData { MessageText = text};

            using (var context = new ApplicationDbContext())
            {
                try
                {
                    md.TargetChannel = context.Channels.FirstOrDefault(p => p.Topic == "Main");
                    md.User = context.Users.FirstOrDefault(p => p.Email == name);
                    context.Messages.Add(md);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}