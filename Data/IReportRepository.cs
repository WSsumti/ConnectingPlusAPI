using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IReportRepository
    {
        void CreateReport(Report report);
        void KeepTrack(Guid id, int income);
    }
}
