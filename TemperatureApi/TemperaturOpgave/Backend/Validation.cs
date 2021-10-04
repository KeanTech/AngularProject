using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Models;

namespace TemperaturOpgave.Backend
{
    public class Validation
    {
        /// <summary>
        /// Validates the input with db 
        /// Returns false if user dont exist or if password is incorrect
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidateUser(string userName, string password)
        {
            ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext();

            var users = context.Users;

            foreach (var item in users)
            {
                if (userName == item.UserName)
                {
                    if (item.Password == Convert.ToBase64String(Hash.HashPasswordWithSalt(Convert.FromBase64String(password), Convert.FromBase64String(item.Salt))))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
