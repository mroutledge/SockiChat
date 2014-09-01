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
                messages = context.Messages.ToList();
            }

            return messages;
        }
    }
}