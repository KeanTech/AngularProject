using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;
using TemperaturOpgave.Models.Authentication;
using TemperaturOpgave.Services;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TemperatureController : Controller
    {
        private DbCommunicator dbCommunicator;
        private readonly IConfiguration configuration;

        public TemperatureController(IConfiguration configuration)
        {
            dbCommunicator = new DbCommunicator();
            this.configuration = configuration;
        }

        /// <summary>
        /// Makes a call to db through the DbCommunicator
        /// returns a null if user dont have access
        /// </summary>
        /// <returns></returns>
        private Task<IEnumerable<TemperatureModel>> LoadData()
        {
            Task<IEnumerable<TemperatureModel>> task = Task<IEnumerable<TemperatureModel>>.Factory.StartNew(() =>
            {
                return dbCommunicator.GetRoomTemperatures();
            });
            return task;
        }

        /// <summary>
        /// Gets the Room Temperatures from db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TemperatureModel>> Get(string apiKey)
        {
            if (apiKey != null && apiKey == configuration["ApiKey"])
            {
                try
                {
                    IEnumerable<TemperatureModel> roomModels = await LoadData();
                    return roomModels;
                }
                catch (Exception ex)
                {
                    return new List<TemperatureModel>() { new TemperatureModel() { RoomName = ex.Message } };
                }
            }
            return null;
        }


    }
}
