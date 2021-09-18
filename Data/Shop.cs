using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class Shop : IShop
    {
        public void CreateShop(Shoper user)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            col.InsertOne(user);
        }

        public void DeleteShop(Guid id)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Id", id);
            col.DeleteOne(target);
        }

        public IEnumerable<Shoper> GetAllShop()
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            return col.Find(new BsonDocument()).ToList();
        }

        public Shoper GetShopById(Guid id)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Id", id);
            try
            {
                return col.Find(target).First();
            }
            catch (Exception)
            {
                Shoper s = null;
                return s;
            }
        }

        public void UpdateShop(Guid id, Shoper user)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Id", id);
            user.Id = col.Find(target).First().Id;
            col.ReplaceOne(target, user);
        }
        public bool CheckName(string name)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Name", name);
            try
            {
                var a = col.Find(target).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
