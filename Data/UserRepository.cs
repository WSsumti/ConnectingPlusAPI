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
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<User>("Users");
            col.InsertOne(user);
        }

        public void DeleteUser(string username)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<User>("Users");
            var target = Builders<User>.Filter.Eq("Account.Username", username);
            col.DeleteOne(target);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<User>("Users");
            return col.Find(new BsonDocument()).ToList();
        }

        public User GetUserByUser(string username)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<User>("Users");
            var target = Builders<User>.Filter.Eq("Account.Username", username);
            try
            {
                return col.Find(target).First();
            }
            catch (Exception)
            {
                User s = null;
                return s;
            }
        }

        public void UpdateUser(string username, User user)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<User>("Users");
            var target = Builders<User>.Filter.Eq("Account.Username", username);
            user.Id = col.Find(target).First().Id;
            col.ReplaceOne(target, user);
        }
    }
}
