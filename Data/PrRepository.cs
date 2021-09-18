using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class PrRepository : IPrRepository
    {
        public void CreatePr(Pr pr)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Pr>("Status");
            col.InsertOne(pr);
        }

        public List<Pr> GetPr(Guid Id)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Pr>("Status");
            var target = Builders<Pr>.Filter.Eq("ShopId", Id);
            try
            {
                return col.Find(target).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void UpdatePr(Guid Id, Pr pr)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Pr>("Status");
            var target = Builders<Pr>.Filter.Eq("Id", Id);
            col.ReplaceOne(target, pr);
        }   
    }
}
