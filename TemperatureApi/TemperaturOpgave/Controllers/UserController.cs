using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Create(string userName, string password)
        {
            User user = new User()
            {
                UserName = userName,
                Salt = Convert.ToBase64String(Hash.GenerateSalt())
            };
            user.Password =  Convert.ToBase64String(Hash.HashPasswordWithSalt(Convert.FromBase64String(password), Convert.FromBase64String(user.Salt)));

            using (ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext())
            {
                context.Add(user);
                context.SaveChanges();
            }

            return new List<string>() { new string("Success") };
        }
    }
}
