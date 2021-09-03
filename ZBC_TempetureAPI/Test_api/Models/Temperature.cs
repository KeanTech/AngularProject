using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_api.Models
{
    public class Temperature
    {
        public DateTime TimeStamp { get; set; }
        public float Celsius { get; set; }
        public int RoomId { get; set; }
    }
}