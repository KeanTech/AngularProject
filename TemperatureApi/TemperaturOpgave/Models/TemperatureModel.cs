using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturOpgave.Models
{
    public class TemperatureModel
    {
        public int Id { get; set; }
        public double Celsius { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string RoomName { get; set; }
    }
}
