using System;
using System.Collections.Generic;

#nullable disable

namespace TemperaturOpgave.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomTemperatures = new HashSet<RoomTemperature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoomTemperature> RoomTemperatures { get; set; }
    }
}
