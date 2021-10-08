using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;
using Xunit;

namespace ApiTest
{
    public class LoginTest
    {
        [Theory]
        [InlineData("Kenneth", "Kean")]
        public void UserLogin_ShouldReturnIEnumerableWithOneUser(string username, string password)
        {
            User user = Validation.ValidateUser(username, password);
            
            IEnumerable<User> expected = new List<User>();

            User user1 = new User() 
            {
                Id = 2,
                Password = "L0wkhfUSxiD78juew/JYf3g133m8G+mSUedeQJ9Ic70=",
                Salt = "w1NAQT6eQPOXR6jO2qYr+ajncZ12m1MrZoXzvZMJilc=",
                UserName = "Kenneth"
                
            };

            IEnumerable<User> actual = new List<User>();

            ((List<User>)actual).Add(user1);

            ((List<User>)expected).Add(user);
            Assert.Equal(expected, actual);
        }
    }
}
