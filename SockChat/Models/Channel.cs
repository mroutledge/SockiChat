using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SockChat.Models
{
    public class Channel
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ChannelId { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public DateTime AddedOn { get; set; }
        public string Topic { get; set; }
    }
}