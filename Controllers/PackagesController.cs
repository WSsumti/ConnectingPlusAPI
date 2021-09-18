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
    public class PackagesController : ControllerBase
    {
        IShopItemRepository _item;
        public PackagesController(IShopItemRepository item)
        {
            _item = item;
        }
        [HttpGet("{id}")]
        public ActionResult<ShopItem> GetItemId(Guid id)
        {
            return Ok(_item.GetItem(id));
        }
        [HttpPost("{id}/topcounter")]
        public ActionResult ProcessAccessCounter(Guid id)
        {
            _item.CounterAccess(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateItems(Guid id, ShopItem item)
        {
            var temp = _item.GetItem(id);
            if (temp != null)
            {
                _item.UpdateItems(id, item);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost()]
        public ActionResult CreateItem(ShopItem item)
        {
            _item.CreateShopItem(item);
            return Ok();
        }
    }
}
