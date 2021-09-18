using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class Shoper
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public string Avatar { get; set; }
        public string CoverPicture { get; set; }
        public Info Information { get; set; }
        public List<ShopItem> Packages { get; set; }
        public List<Guid> Posts { get; set; }
        public List<string> KeyRoom { get; set; }
    }
}
