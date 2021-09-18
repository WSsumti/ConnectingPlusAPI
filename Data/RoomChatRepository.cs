using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class RoomChatRepository : IRoomChatRepository
    {
        public void CreateRoom(RoomChat room)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<RoomChat>("RoomChat");
            col.InsertOne(room);
        }

        public RoomChat GetRoom(string key)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<RoomChat>("RoomChat");
            var target = Builders<RoomChat>.Filter.Eq("Key", key);
            try
            {
                return col.Find(target).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateRoom(string key, RoomChat room)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<RoomChat>("RoomChat");
            var target = Builders<RoomChat>.Filter.Eq("Key", key);
            col.ReplaceOne(target, room);
        }
    }
}
