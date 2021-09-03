using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_api.Models
{
    public class TemperatureModel
    {
        public int Id { get; set; }
        public double Celsius { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}