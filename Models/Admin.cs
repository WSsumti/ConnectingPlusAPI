using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class Admin
    {
        [BsonId]
        public Guid Id { get; set; }
        public Account Account { get; set; }
    }
}
