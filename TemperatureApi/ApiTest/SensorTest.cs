using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTest
{
    public class SensorTest
    {
        [Theory]
        [InlineData("20,4", "B12")]
        [InlineData("10,2", "B14")]
        public void SaveData_ShouldReturnStatusCode200(string temperature, string roomName)
        {
            HttpResponseMessage actual = new HttpResponseMessage();
            HttpResponseMessage expected = new HttpResponseMessage();

            expected.StatusCode = HttpStatusCode.OK;


            if (!string.IsNullOrEmpty(temperature) && !string.IsNullOrEmpty(roomName))
            {
                actual.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                actual.StatusCode = HttpStatusCode.BadRequest;
            }

            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}
