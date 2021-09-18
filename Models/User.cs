using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public string Quote { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public bool IsShoper { get; set; }
        public Account Account { get; set; }
        public string Address { get; set; }
        public List<Shoper> FollowingShops { get; set; }
        public List<string> SubAddress { get; set; }
        public List<Bill> DeliveryItem { get; set; }
        public List<string> KeyRoom { get; set; }

    }
}
