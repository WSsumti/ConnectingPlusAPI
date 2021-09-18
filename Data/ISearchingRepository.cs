using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface ISearchingRepository
    {
        IEnumerable<Searche> ReturnSearching(string keyword);
    }
}
