using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ZBCRoomInfoDbContext context;

        public UserController(ZBCRoomInfoDbContext context)
        {
            this.context = context;
        }
    }
}
