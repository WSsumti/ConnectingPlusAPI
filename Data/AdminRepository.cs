using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class AdminRepository : IAdminRepository
    {
        public bool Authen(string pass)
        {
            var context = new MongoContext("PlusBases");
            var col = context.db.GetCollection<Admin>("Admin");
            var target = Builders<Admin>.Filter.Eq("Account.Username", "admin");
            try
            {
                var ad = col.Find(target).First();
                if (ad.Account.Password == pass)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
