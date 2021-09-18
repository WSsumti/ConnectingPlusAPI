using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string User { get; set; }
        public bool IsOwner { get; set; }
    }
}
