using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZBC_TempetureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        [HttpPost]
        public string Post(string input)
        {
            return "";   
        }


    }
}
