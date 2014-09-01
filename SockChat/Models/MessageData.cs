using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity;

namespace SockChat.Models
{
    public class MessageData
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MessageId { get; set; }
        public ApplicationUser User { get; set; }
        public string MessageText { get; set; }
        public string Font { get; set; }
        public string Colour { get; set; }
        public string BackgroundColour { get; set; }
        public int FontSize { get; set; }
        public DateTime Created { get; set; }
        public Channel TargetChannel { get; set; }
        public string TargetUserId { get; set; }
    }
}