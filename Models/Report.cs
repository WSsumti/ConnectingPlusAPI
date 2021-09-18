using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Models
{
    public class Report
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public Decimal TotalIncome { get; set; }
    }
}
