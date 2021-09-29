using System;
using System.Collections.Generic;
using System.Linq;
using ZbcTemperatureApi.Models;
using ZbcTemperatureApi.DataAccess;

namespace ZbcTemperatureApi.DataAccess
{
    public static class DbCommunicator
    {
        private static ZBCRoomInfoDbEntities1 infoDb = new ZBCRoomInfoDbEntities1();
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

        public static TemperatureModel ConvertToTemperatureModel(Temperature temperature, string roomName)
        {
            if (temperature == null)
                temperature = new Temperature();

            TemperatureModel temperatureModel = new TemperatureModel()
            {
                Id = temperature.Id,
                Celsius = temperature.Celsius,
                TimeStamp = temperature.TimeStamp,
                Room = roomName
            };
            return temperatureModel;
        }

        public static List<Temperature> GetAllTemperatures()
        {
            return infoDb.Temperature.ToList();
        }

        public static List<TemperatureModel> GetTemperatures()
        {
            List<TemperatureModel> temperatureModels = new List<TemperatureModel>();
            var temperatures = infoDb.Temperature.ToList();
            var rooms = infoDb.Room.ToList();
            var roomTemps = infoDb.RoomTemperatures.ToList();

            foreach (var item in temperatures)
            {
                if (item != null)
                {
                    foreach (var roomTemp in roomTemps)
                    {
                        if (roomTemp.FK_Temperature_Id == item.Id)
                        {
                            Room room = rooms.Where(x => x.Id == roomTemp.Id).FirstOrDefault();
                            temperatureModels.Add(ConvertToTemperatureModel(item, room.Name));
                        }
                    }
                }
            }

            return temperatureModels;
        }

        public static TemperatureModel GetTemperature(int id)
        {
            var roomTemps = infoDb.Temperature.Where(x => x.Id == id).FirstOrDefault();

            return ConvertToTemperatureModel(roomTemps, "");
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

        //----------------------------------------------------- RoomTemperatures

        public static void Add(RoomTemperatures roomTemperature)
        {
            infoDb.RoomTemperatures.Add(roomTemperature);
            infoDb.SaveChanges();
        }

        public static List<RoomTemperatures> GetRoomTemperatures()
        {
            return infoDb.RoomTemperatures.ToList();
        }

    }
}