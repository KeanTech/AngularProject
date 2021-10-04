using System;
using System.Collections.Generic;

#nullable disable

namespace TemperaturOpgave.Models
{
    public partial class Temperature
    {
        public Temperature()
        {
            RoomTemperatures = new HashSet<RoomTemperature>();
        }

        public int Id { get; set; }
        public double Celsius { get; set; }
        public DateTime? TimeStamp { get; set; }

        public virtual ICollection<RoomTemperature> RoomTemperatures { get; set; }
    }
}
