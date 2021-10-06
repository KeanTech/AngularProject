using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string value;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
            value = configuration.GetValue<string>("Key");
        }

        //[HttpGet]
        //public IActionResult UserLogin(string username, string password)
        //{
        //    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        //    {
        //        if (Validation.ValidateUser(username, password))
        //        {
        //            byte[] userBytes = Encoding.UTF8.GetBytes(username);
        //            byte[] saltBytes = Encoding.UTF8.GetBytes(value);
        //            byte[] hashedBytes = Hash.HashPasswordWithSalt(userBytes, saltBytes);
        //            string hashedValue = Convert.ToBase64String(hashedBytes);

        //            Response.Cookies.Append("zbcRoomInfo", hashedValue);
        //            return Ok();
        //        }
        //    }
        //    return BadRequest();
        //}

        [HttpGet]
        public IEnumerable<User> UserLogin(string username, string password)
        {
            IEnumerable<User> users = new List<User>();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                User user = Validation.ValidateUser(username, password);
                ((List<User>)users).Add(user);
                return users;
            }
            return users;
        }
    }
}
