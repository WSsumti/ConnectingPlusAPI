using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IPrRepository
    {
        void CreatePr(Pr pr);
        List<Pr> GetPr(Guid Id);
        void UpdatePr(Guid Id, Pr pr);
    }
}
