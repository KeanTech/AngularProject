using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;
using TemperaturOpgave.Models.Authentication;
using TemperaturOpgave.Services;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IUserService service;
        private readonly string value;

        public LoginController(IConfiguration configuration, IUserService service)
        {
            this.configuration = configuration;
            this.service = service;
            value = configuration.GetValue<string>("Key");
        }
        
        [HttpPost("authenticate")]
        public AuthenticateResponse UserLogin(AuthenticateRequest model)
        {
            var response = service.Authenticate(model);
            
            User user = Validation.ValidateUser(model.Username, model.Password);
            if (response != null && user != null)
            {
                Response.Cookies.Append("zbcRoomInfo", Convert.ToBase64String(Hash.HashString(user.UserName)) + "." + user.Password);
                Response.Cookies.Append("token", response.Token);
                return response;
            }

            return response;
        }
    }
}
