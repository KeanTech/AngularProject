using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TemperatureController : Controller
    {
        private readonly ZBCRoomInfoDbContext context;

        public TemperatureController(ZBCRoomInfoDbContext context)
        {
            this.context = context;
        }

        private Task<IEnumerable<TemperatureModel>> LoadData()
        {
            if (Request.Cookies["zbcRoomInfo"] != null)
            {
                Task<IEnumerable<TemperatureModel>> task = Task<IEnumerable<TemperatureModel>>.Factory.StartNew(() =>
                {
                    IEnumerable<TemperatureModel> temperatureModels = new List<TemperatureModel>();
                    var temps = context.Temperatures.ToList();
                    var roomTemps = context.RoomTemperatures.ToList();
                    var rooms = context.Rooms.ToList();

                    foreach (var roomtemp in roomTemps)
                    {
                        foreach (var temp in temps)
                        {
                            TemperatureModel temperatureModel = new TemperatureModel();

                            if (temp.TimeStamp != null && roomtemp.TemperatureId == temp.Id)
                            {
                                temperatureModel.RoomName = rooms.Where(x => x.Id == roomtemp.RoomId).FirstOrDefault().Name;
                                temperatureModel.Id = temp.Id;
                                temperatureModel.TimeStamp = temp.TimeStamp;
                                temperatureModel.Celsius = temp.Celsius;
                                ((List<TemperatureModel>)temperatureModels).Add(temperatureModel);
                            }
                        }
                    }
                    return temperatureModels;
                });

                return task;
            }
            return null;
        }

        [HttpGet]
        public async Task<IEnumerable<TemperatureModel>> Get()
        {
            try
            {
                IEnumerable<TemperatureModel> roomModels = await LoadData();
                return roomModels;
            }
            catch (Exception ex)
            {
                return new List<TemperatureModel>() { new TemperatureModel() { RoomName =  ex.Message} };
            }
        }
    }
}
