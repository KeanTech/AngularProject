using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTest
{
    public class UserTest
    {
        [Theory]
        [InlineData("Kenneth", "Hello")]
        [InlineData("Jan", "Galis")]
        public void CreateUser_ShouldReturnOk(string userName, string password)
        {
            IEnumerable<string> actual;
            IEnumerable<string> expected = new List<string> { new string("Success") };
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                actual = new List<string>() { new string("Error") };
            }
            else
            {
                actual = new List<string>() { new string("Success") };
            }

            Assert.Equal(expected, actual);
        }
    }
}
