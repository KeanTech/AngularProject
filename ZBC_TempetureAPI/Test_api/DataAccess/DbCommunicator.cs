using System;
using System.Collections.Generic;
using System.Linq;
using ZBCTempInfoApi.Models;

namespace ZBCTempInfoApi.DataAccess
{
    public static class DbCommunicator
    {
        private static ZBCRoomInfoDb infoDb = new ZBCRoomInfoDb();
        //------------------------------------------------------------- Room Methods

        public static List<Room> GetRooms()
        {
            return infoDb.Room.ToList();
        }

        public static Room GetRoom(int id)
        {
            return infoDb.Room.Where(x => x.Id == id).FirstOrDefault();
        }

        public static void Add(Room room)
        {
            infoDb.Room.Add(room);
            infoDb.SaveChanges();
        }

        public static void Delete(Room room)
        {
            infoDb.Room.Remove(room);
            infoDb.SaveChanges();
        }

        public static void Update(Room room)
        {
            Room selectedRoom = infoDb.Room.Where(x => x.Id == room.Id).FirstOrDefault();
            infoDb.Room.Remove(selectedRoom);
            infoDb.Room.Add(room);
            infoDb.SaveChanges();
        }

        //---------------------------------------------------  Temperature Methods

        public static TemperatureModel ConvertToTemperatureModel(Temperature temperature)
        {
            if (temperature == null)
                temperature = new Temperature();

            TemperatureModel temperatureModel = new TemperatureModel()
            {
                Id = temperature.Id,
                Celsius = temperature.Celsius,
                TimeStamp = temperature.TimeStamp ?? new DateTime()
            };
            return temperatureModel;
        }

        public static List<TemperatureModel> GetTemperatures()
        {
            List<TemperatureModel> temperatureModels = new List<TemperatureModel>();
            var temperatures = infoDb.Temperature.ToList();
            var rooms = infoDb.Room.ToList();
            var roomTemps = infoDb.RoomTemperatures.ToList();

            foreach (var item in temperatures)
            {
                if(item != null)
                temperatureModels.Add(ConvertToTemperatureModel(item));
            }

            return temperatureModels;
        }

        public static TemperatureModel GetTemperature(int id)
        {
            return ConvertToTemperatureModel(infoDb.Temperature.Where(x => x.Id == id).FirstOrDefault());
        }

        public static void Add(Temperature temperature)
        {
            infoDb.Temperature.Add(temperature);
            infoDb.SaveChanges();
        }

        public static void Delete(Temperature temperature)
        {
            infoDb.Temperature.Remove(temperature);
            infoDb.SaveChanges();
        }
    }
}