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
    public class SearchingRepository : ISearchingRepository
    {
        public IEnumerable<Searche> ReturnSearching(string keyword)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            var target = Builders<Searche>.Filter.Where(value => value.Name.ToLowerInvariant().Contains(keyword));
            List<Searche> r = new List<Searche>();
            if (col.Find(target).ToList().Count<10)
            {
                r = col.Find(target).ToList();
            }
            else
            {
                r = col.Find(target).ToList().Reverse<Searche>().Take(10).ToList();
            }
            return r;
        }
    }
}
