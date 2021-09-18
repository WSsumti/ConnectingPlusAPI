using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IShop
    {
        Shoper GetShopById(Guid id);
        IEnumerable<Shoper> GetAllShop();
        void CreateShop(Shoper user);
        void UpdateShop(Guid id, Shoper user);
        void DeleteShop(Guid id);
        bool CheckName(string name);
    }
}
