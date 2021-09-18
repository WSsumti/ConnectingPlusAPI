using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class Pr
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }
        public bool IsPr { get; set; }
        public int? N0 { get; set; }
        public List<string> Comments { get; set; }
    }
}
