using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IShopItemRepository
    {
        void CounterAccess(Guid id);
        ShopItem GetItem(Guid id);
        void UpdateItems(Guid id, ShopItem item);
        void CreateShopItem(ShopItem item);
    }
}
