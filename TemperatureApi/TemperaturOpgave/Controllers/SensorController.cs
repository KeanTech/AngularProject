using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public HttpResponseMessage SaveData(string temperature, string roomName)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            // Save temp to db here 
            if (!string.IsNullOrEmpty(temperature) && !string.IsNullOrEmpty(roomName))
            {
                ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext();
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

                    Room room = new Room()
                    {
                        Name = roomName
                    };
                    context.Rooms.Add(room);

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

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
    }
}
