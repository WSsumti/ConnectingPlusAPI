using ConnectingPlusAPI.Models;
using ConnectingPlusAPI.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class ReportRepository : IReportRepository
    {
        public void CreateReport(Report report)
        {
            var context = new MongoContext("Processes");
            var col = context.db.GetCollection<Report>("OwnerReport");
            col.InsertOne(report);
        }

        public void KeepTrack(Guid id, int income)
        {
            var context = new MongoContext("Processes");
            var col = context.db.GetCollection<Report>("OwnerReport");
            var target = Builders<Report>.Filter.Eq("ShopId", id);
            Report r = col.Find(target).First();
            r.TotalIncome += income;
            col.ReplaceOne(target, r);
        }
    }
}
