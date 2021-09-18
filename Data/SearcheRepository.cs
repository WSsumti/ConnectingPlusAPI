using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class SearcheRepository : ISearcheRepository
    {
        public void CreateSearche(Searche search)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            col.InsertOne(search);
        }

        public void DeleteSearche(Guid id)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            var target = Builders<Searche>.Filter.Eq("Id", id);
            col.DeleteOne(target);
        }

        public Searche GetSearche(Guid id)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            var target = Builders<Searche>.Filter.Eq("Id", id);
            try
            {
                return col.Find(target).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Searche> ReturnSearching(string keyword, int order)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            var target = Builders<Searche>.Filter.Where(value => value.Name.ToLowerInvariant().Contains(keyword));
            List<Searche> r = new List<Searche>();
            var s = col.Find(target).ToList();
            int i = order;
            try
            {
                while (s[i] != null)
                {
                    r.Add(s[i]);
                    if (i > order + 50)
                    {
                        break;
                    }
                    ++i;
                }
            }
            catch (Exception)
            {
            }
            return r;
        }

        public void UpdateSearche(Guid id, Searche search)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<Searche>("Searching");
            var target = Builders<Searche>.Filter.Eq("Id", id);
            search.Id = col.Find(target).First().Id;
            col.ReplaceOne(target, search);
        }
        public IEnumerable<OnlyString> GetKeyword(string keyword)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<OnlyString>("Keyword");
            var target = Builders<OnlyString>.Filter.Where(value => value.Keyword.ToLowerInvariant().Contains(keyword));
            var r = col.Find(target).ToList();
            try
            {
                if (r.Count >=10)
                {
                    return r.Take<OnlyString>(10); 
                }
                else
                {
                    return r;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void CreateKeyword(OnlyString keyword)
        {
            var context = new MongoContext("Searching");
            var col = context.db.GetCollection<OnlyString>("Keyword");
            keyword.Keyword.ToLowerInvariant();
            var target = Builders<OnlyString>.Filter.Where(value => value.Keyword.ToLowerInvariant().Contains(keyword.Keyword));
            if (!col.Find(target).ToList().Any())
            {
                col.InsertOne(keyword);
            }

        }
    }
}
