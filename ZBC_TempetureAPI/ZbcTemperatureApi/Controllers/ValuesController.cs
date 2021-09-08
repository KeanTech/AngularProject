using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Web.Http;
using ZbcTemperatureApi.DataAccess;
using ZbcTemperatureApi.Models;

namespace ZbcTemperatureApi.Controllers
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

        public string Get(int id)
        {
            var url = Request.RequestUri.AbsoluteUri.Split('?').Length;
            if (url > 2)
            {
                var temp = Request.RequestUri.AbsoluteUri.Split('?')[2].Split('=')[1].Split('&')[0];
                var loc = Request.RequestUri.AbsoluteUri.Split('?')[3].Split('=')[1];

                return Sensor(temp, loc);
            }
            
            if(id == 0)
            {
               return GetTemps();
            }
                    
            return JsonSerializer.Serialize<TemperatureModel>(DbCommunicator.GetTemperature(id) ?? new TemperatureModel());
        }

        public string GetTemps()
        {
            return JsonSerializer.Serialize<List<TemperatureModel>>(DbCommunicator.GetTemperatures());
        }

    }
}
