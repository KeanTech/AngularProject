using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        public TemperatureController()
        {
            dbCommunicator = new DbCommunicator();
        }
        
        /// <summary>
        /// Makes a call to db through the DbCommunicator
        /// returns a null if user dont have access
        /// </summary>
        /// <returns></returns>
        private Task<IEnumerable<TemperatureModel>> LoadData()
        {
            if (LoadDataValidation())
            {
                Task<IEnumerable<TemperatureModel>> task = Task<IEnumerable<TemperatureModel>>.Factory.StartNew(() =>
                {
                    return dbCommunicator.GetRoomTemperatures();
                });
                return task;
            }
            return null;
        }

        /// <summary>
        /// Gets the Room Temperatures from db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [CostumAuthorize]
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

        /// <summary>
        /// Validates the clients cookie 
        /// Returns false if user token is invalid or user dont exist
        /// Else true
        /// </summary>
        /// <returns></returns>
        private bool LoadDataValidation()
        {
            User user = dbCommunicator.GetUsers().ToList().FirstOrDefault(x => Convert.ToBase64String(Hash.HashString(x.UserName)) == Request.Cookies["zbcRoomInfo"].Split(".")[0]);
            if (Request.Cookies["Token"] == user.Token)
            {
                return true;
            }
            return false;
        }
    }
}
