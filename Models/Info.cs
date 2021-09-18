using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class Info
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int nFollowers { get; set; }
        public int nLikers { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Likers { get; set; }
        public int Income { get; set; }
    }
}
