using ConnectingPlusAPI.Data;
using ConnectingPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        ISearcheRepository _search;
        public SearchesController(ISearcheRepository search)
        {
            _search = search;
        }
        [HttpGet("allsearches/{keyword}/{order}")]
        public IEnumerable<Searche> GetAllSearches(string keyword, int order)
        {
            return _search.ReturnSearching(keyword, order);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Searche> GetSearch(Guid id)
        {
            return Ok(_search.GetSearche(id));
        }

        [HttpPost]
        public ActionResult CreateSearch(Searche search)
        {
            _search.CreateSearche(search);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSearch(Guid id)
        {
            var temp = _search.GetSearche(id);

            if (temp != null)
            {
                _search.DeleteSearche(id);
                return Ok(); 
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSearch(Guid id, Searche search)
        {
            var temp = _search.GetSearche(id);
            if (temp != null)
            {
                _search.UpdateSearche(id, search);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("keyword")]
        public ActionResult CreateKeyword(OnlyString keyword)
        {
            _search.CreateKeyword(keyword);
            return Ok();
        }
        [HttpGet("keyword/{keyword}")]
        public ActionResult<IEnumerable<OnlyString>> GetKeyword(string keyword)
        {
            return (Ok(_search.GetKeyword(keyword)));
        }
    }
}
