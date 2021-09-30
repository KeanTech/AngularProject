using System;
using System.Collections.Generic;

#nullable disable

namespace TemperaturOpgave.Models
{
    public partial class RoomTemperature
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? TemperatureId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Temperature Temperature { get; set; }
    }
}
