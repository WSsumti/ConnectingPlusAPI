using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IAdminRepository 
    {
        bool Authen(string pass);
    }
}
