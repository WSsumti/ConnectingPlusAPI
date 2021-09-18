using ConnectingPlusAPI.Data;
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
    public class AdminController : ControllerBase
    {
        IAdminRepository _a;
        public AdminController(IAdminRepository a)
        {
            _a = a;
        }
        [HttpGet("{pass}")]
        public ActionResult<bool> Authen(string pass)
        {
            return Ok(_a.Authen(pass));
        }
    }
}
