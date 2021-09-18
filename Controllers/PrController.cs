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
    public class PrController : ControllerBase
    {
        IPrRepository _pr;
        public PrController(IPrRepository pr)
        {
            _pr = pr;
        }
        [HttpPost()]
        public ActionResult CreatePr(Pr pr)
        {
            _pr.CreatePr(pr);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<List<Pr>> GetPr(Guid id)
        {
            return Ok(_pr.GetPr(id));
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePr(Guid id, Pr pr)
        {
            _pr.UpdatePr(id, pr);
            return Ok();
        }
    }
}
