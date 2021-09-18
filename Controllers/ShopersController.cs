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
    public class ShopersController : ControllerBase
    {
        IShop _shop;
        public ShopersController(IShop shop)
        {
            _shop = shop;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Shoper>> GetAllUsers()
        {
            var users = _shop.GetAllShop();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<Shoper> GetUserByUser(Guid id)
        {
            var user = _shop.GetShopById(id);
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<Shoper> CreateUser(Shoper user)
        {
            _shop.CreateShop(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateShop(Guid id, Shoper user)
        {
            var temp = _shop.GetShopById(id);
            if (temp != null)
            {
                _shop.UpdateShop(id, user);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            var user = _shop.GetShopById(id);
            if (user != null)
            {
                _shop.DeleteShop(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("checkshop/{name}")]
        public ActionResult<bool> CheckName(string name)
        {
            return Ok(_shop.CheckName(name));
        }
    }
}
