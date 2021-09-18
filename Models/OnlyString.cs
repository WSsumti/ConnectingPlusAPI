using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class OnlyString
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Keyword { get; set; }
    }
}
