using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZbcTemperatureApi.Models
{
    public class TemperatureModel
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public double Celsius { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}