using SockChat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                messages = context.Messages.Include(p => p.User).OrderByDescending( p => p.MessageId).Take(15).ToList();
            }

            return messages.OrderBy(p => p.MessageId).ToList();
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