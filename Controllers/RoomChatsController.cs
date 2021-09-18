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
    public class RoomChatsController : ControllerBase
    {
        IRoomChatRepository _room;
        public RoomChatsController(IRoomChatRepository room)
        {
            _room = room;
        }
        [HttpPost()]
        public ActionResult CreateRoom(RoomChat room)
        {
            _room.CreateRoom(room);
            return Ok();
        }
        [HttpPut("{key}")]
        public ActionResult UpdateRoom(string key, RoomChat room)
        {
            _room.UpdateRoom(key, room);
            return Ok();
        }
        [HttpGet("{key}")]
        public ActionResult<RoomChat> GetRoom(string key)
        {
            return Ok(_room.GetRoom(key));
        }
    }
}
