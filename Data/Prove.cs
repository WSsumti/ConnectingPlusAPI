using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class Prove : IProve
    {
        public void CreatePending(Request request)
        {
            var context = new MongoContext("Processes");
            var col = context.db.GetCollection<Request>("ProveList");
            col.InsertOne(request);
        }

        public void CreateShopPending(Shoper shoper)
        {
            var context = new MongoContext("Processes");
            var col = context.db.GetCollection<Shoper>("PendingShop");
            col.InsertOne(shoper);
        }
        public List<Request> GetAllRequest()
        {
            var context = new MongoContext("Processes");
            var col = context.db.GetCollection<Request>("ProveList");
            return col.Find(Builders<Request>.Filter.Empty).ToList();
        }
    }
}
