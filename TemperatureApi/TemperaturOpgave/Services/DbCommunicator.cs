using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Services
{
    public class DbCommunicator : IDisposable
    {
        private ZBCRoomInfoDbContext dbContext;
        public DbCommunicator()
        {
            dbContext = new ZBCRoomInfoDbContext();
        }

        public IEnumerable<User> GetUsers() 
        {
            return dbContext.Users.ToList() ?? new List<User>();        
        }

        public User GetUserById(int id)
        {
            return dbContext.Users.ToList().FirstOrDefault(x => x.Id == id) ?? new User();
        }

        public IEnumerable<TemperatureModel> GetRoomTemperatures()
        {
            IEnumerable<TemperatureModel> temperatureModels = new List<TemperatureModel>();
            var temps = dbContext.Temperatures.ToList();
            var roomTemps = dbContext.RoomTemperatures.ToList();
            var rooms = dbContext.Rooms.ToList();

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
        }

        public void Dispose()
        {
            dbContext = null;
        }
    }
}
