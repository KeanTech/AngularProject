using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public HttpResponseMessage Sensor(string temperature, string location)
        {
            HttpResponseMessage response;
            // Save temp to db here 
            if (!string.IsNullOrEmpty(temperature) && !string.IsNullOrEmpty(location))
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
                    DbCommunicator.Add(temperatureModel);

                    Room room = new Room() 
                    {
                        Name = location
                    };
                    DbCommunicator.Add(room);

                    RoomTemperatures roomTemperatures = new RoomTemperatures()
                    {
                        FK_Room_Id = DbCommunicator.GetRooms().Where(x => x.Name == room.Name).FirstOrDefault().Id,
                        Id = DbCommunicator.GetRooms().Where(x => x.Name == room.Name).FirstOrDefault().Id,
                        FK_Temperature_Id = DbCommunicator.GetAllTemperatures().Where(x => x.TimeStamp == temperatureModel.TimeStamp).FirstOrDefault().Id,
                        Room = room,
                        Temperature = temperatureModel
                    };
                    DbCommunicator.Add(roomTemperatures);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    
                    return response;
                }
            }
            response = Request.CreateResponse(HttpStatusCode.BadRequest);

            return response;
        }

        public HttpResponseMessage Get(int ? id)
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

            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK);
            message.Content = new StringContent(JsonSerializer.Serialize<TemperatureModel>(DbCommunicator.GetTemperature(id ?? 1) ?? new TemperatureModel()), Encoding.UTF8, "application/json");
            return message;
        }

        public HttpResponseMessage GetTemps()
        {
            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK);
            message.Content = new StringContent(JsonSerializer.Serialize<List<TemperatureModel>>(DbCommunicator.GetTemperatures()), Encoding.UTF8, "application/json");
            return message;
        }

    }
}
