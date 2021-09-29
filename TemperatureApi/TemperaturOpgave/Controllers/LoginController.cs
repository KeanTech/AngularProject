using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult UserLogin(string username, string password)
        {

            Response.Cookies.Append("zbcRoomInfo", "Works");
            return Ok();
        }
    }
}
