using System;
using System.Globalization;
using System.Web.Http;
using System.Text.Json;
using Test_api.Models;

namespace Test_api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get(string temp)
        {
            // Save temp to db here 

            Temperature temperature = new Temperature();
            temperature.Celsius = float.Parse(temp);
            temperature.TimeStamp = DateTime.UtcNow.Date;
            temperature.RoomId = 1;

            return JsonSerializer.Serialize(temperature).Replace(temperature.TimeStamp.ToString(), temperature.TimeStamp.ToUniversalTime().ToString("r", CultureInfo.CurrentCulture));
        }

     
    }
}
