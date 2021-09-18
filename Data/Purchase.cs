using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class Purchase : IPurchase
    {
        public bool CheckInStore(Guid ShopId, int pos)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Id", ShopId);
            Shoper s = col.Find(target).First();
            if (s.Packages[pos].QuantityInShop <=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PurchaseItem(Guid ShopId, int pos, int quan)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Shoper>("Shopers");
            var target = Builders<Shoper>.Filter.Eq("Id", ShopId);
            Shoper s = col.Find(target).First();
            s.Packages[pos].QuantityInShop -= quan;
            s.Packages[pos].NBuyers++;
            col.ReplaceOne(target, s);
        }
    }
}
