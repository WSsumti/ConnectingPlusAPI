using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class ShopItemsRepository : IShopItemRepository
    {
        public void CounterAccess(Guid id)
        {
            var item = GetItem(id);
            ++item.Access;
            UpdateItems(id, item);
        }

        public void CreateShopItem(ShopItem item)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<ShopItem>("Packages");
            col.InsertOne(item);
        }

        public ShopItem GetItem(Guid id)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<ShopItem>("Packages");
            var target = Builders<ShopItem>.Filter.Eq("Id", id);
            try
            {
                return col.Find(target).First();
            }
            catch (Exception)
            {
                ShopItem i = null;
                return i;
            }
        }

        public void UpdateItems(Guid id, ShopItem item)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<ShopItem>("Packages");
            var target = Builders<ShopItem>.Filter.Eq("Id", id);
            item.Id = col.Find(target).First().Id;
            col.ReplaceOne(target, item);
        }   
        
    }
}
