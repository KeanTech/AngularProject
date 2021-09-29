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
    public class TemperatureController : Controller
    {
        private readonly IConfiguration configuration;

        public TemperatureController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            if (Request.Cookies["zbcRoomInfo"] != null)
            {
                string jsonValue;
                using (ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext(configuration))
                {
                    jsonValue = JsonSerializer.Serialize<List<User>>(context.Users.ToList());
                }
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
                return message;
            }
            else
            {
                message.StatusCode = HttpStatusCode.BadRequest;
                message.Content = new StringContent("");
                return message;
            }
        }
    }
}
