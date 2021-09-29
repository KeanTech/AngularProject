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
        public bool ValidateUser(string userName, string password)
        {
            using (ZBCRoomInfoDbContext context = new ZBCRoomInfoDbContext())
            {
                var users = context.Users;

                foreach (var item in users)
                {
                    if (userName == item.UserName)
                    {
                        if (item.Password == password)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
