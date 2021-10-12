using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ZBCRoomInfoDbContext context;

        public SensorController(IConfiguration configuration, ZBCRoomInfoDbContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [HttpPost]
        public HttpResponseMessage SaveData(string temperature, string roomName, string apiKey)
        {
            HttpResponseMessage response = new HttpResponseMessage();
           
            if (configuration["ApiKey"] == apiKey)
            {
                if (!string.IsNullOrEmpty(temperature) && !string.IsNullOrEmpty(roomName))
                {
                    double temp;
                    double.TryParse(temperature, out temp);
                    if (temp != 0)
                    {
                        Temperature temperatureModel = new Temperature()
                        {
                            TimeStamp = DateTime.Now,
                            Celsius = double.Parse(temperature)
                        };

                        context.Temperatures.Add(temperatureModel);
                        context.SaveChanges();
                        Room room = new Room()
                        {
                            Name = roomName
                        };
                        context.Rooms.Add(room);
                        context.SaveChanges();
                        RoomTemperature roomTemperatures = new RoomTemperature()
                        {
                            RoomId = context.Rooms.FirstOrDefault(x => x.Name == room.Name).Id,
                            TemperatureId = context.Temperatures.FirstOrDefault(x => x.TimeStamp == temperatureModel.TimeStamp).Id
                        };

                        context.RoomTemperatures.Add(roomTemperatures);
                        context.SaveChanges();
                        response.StatusCode = HttpStatusCode.OK;

                        return response;
                    }
                }
            }
            
            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
    }
}
