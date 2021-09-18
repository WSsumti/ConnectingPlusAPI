using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IPurchase
    {
        bool CheckInStore(Guid ShopId, int pos);
        void PurchaseItem(Guid ShopId, int pos, int quan);
    }
}
