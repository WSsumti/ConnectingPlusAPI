using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface ISearcheRepository
    {
        //get
        Searche GetSearche(Guid id);
        // post
        void CreateSearche(Searche search);
        //update
        void UpdateSearche(Guid id, Searche search);
        //delete
        void DeleteSearche(Guid id);
        //For Searching Algo
        IEnumerable<Searche> ReturnSearching(string keyword, int order);
        IEnumerable<OnlyString> GetKeyword(string keyword);
        void CreateKeyword(OnlyString keyword);
    }
}
