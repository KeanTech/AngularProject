using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Models;
using TemperaturOpgave.Models.Authentication;
using TemperaturOpgave.Services;

namespace TemperaturOpgave.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    { 
        private readonly Appsettings appSettings;
        private DbCommunicator dbCommunicator;

        public UserService(IOptions<Appsettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            dbCommunicator = new DbCommunicator();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = Validation.ValidateUser(model.Username, model.Password); 

            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return dbCommunicator.GetUsers();
        }

        public User GetById(int id)
        {
            return dbCommunicator.GetUserById(id);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
