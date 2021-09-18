using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IProve
    {
        void CreatePending(Request request);
        void CreateShopPending(Shoper shoper);
        List<Request> GetAllRequest();
    }
}
