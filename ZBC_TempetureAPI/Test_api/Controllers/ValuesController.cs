using System;
using System.Globalization;
using System.Web.Http;
using System.Text.Json;
using Test_api.DataAccess;
using System.Linq;
using System.Collections.Generic;
using Test_api.Models;
using System.Web;

namespace Test_api.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public string Sensor(string temperature, string location)
        {
            // Save temp to db here 
            if (!string.IsNullOrEmpty(temperature) && !string.IsNullOrEmpty(location))
            {
                double temp;
                double.TryParse(temperature, out temp);
                if (temp != 0)
                {
                    Temperature temperatureModel = new Temperature()
                    {
                        TimeStamp = DateTime.UtcNow,
                        Celsius = double.Parse(temperature)
                    };
                    DbCommunicator.Add(temperatureModel);
                    return "Ok";
                }
            }
            return "Error";
        }

        public string GetTemp(int id)
        
        {
            if(id == 0)
            {
                return "Error";
            }
            if(id == 10)
            {
               return GetTemps();
            }
                    
            return JsonSerializer.Serialize<TemperatureModel>(DbCommunicator.GetTemperature(id));
        }

        public string GetTemps()
        {
            return JsonSerializer.Serialize<List<TemperatureModel>>(DbCommunicator.GetTemperatures());
        }

    }
}
