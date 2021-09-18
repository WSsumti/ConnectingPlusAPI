using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Services
{
    public class MongoContext
    {
        private IMongoClient client { get; set; }
        public IMongoDatabase db { get; set; }
        public MongoContext(string dbname)
        {
            client = new MongoClient("mongodb+srv://zzumti:Nun0izdab3zT@connectplus.5dla7.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            db = client.GetDatabase(dbname);
        }
    }
}
