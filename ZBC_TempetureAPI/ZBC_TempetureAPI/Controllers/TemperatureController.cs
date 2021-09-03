using Microsoft.AspNetCore.Mvc;

namespace ZBC_TempetureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        [Route("[action]")]
        [HttpGet]
        public string Get(string temp)
        {



            return temp;
        }


    }
}
