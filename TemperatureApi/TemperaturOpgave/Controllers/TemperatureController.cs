using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TemperatureController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            if (Request.Cookies["zbcRoomInfo"] != null)
            {
                IEnumerable<User> jsonValue;
                using (ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext())
                {
                    var users = context.Users.ToArray();
                    jsonValue = users;
                }
                return jsonValue;
            }
            else
            {
                IEnumerable<User> emptyList = new List<User>();
                return emptyList;
            }
        }

    }
}
