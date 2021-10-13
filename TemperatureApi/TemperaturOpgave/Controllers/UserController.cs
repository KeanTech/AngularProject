using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;
using TemperaturOpgave.Services;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private DbCommunicator db = new DbCommunicator();
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        // Used by arduino
        public IEnumerable<User> GetUsers(string apiKey)
        {
            if (apiKey == configuration["ApiKey"])
            {
                return db.GetUsers();
            }

            return null;
        }
    }
}
