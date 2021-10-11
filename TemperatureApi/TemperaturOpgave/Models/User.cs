using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable

namespace TemperaturOpgave.Models
{
    public partial class User : IEquatable<User>
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public bool Equals(User other)
        {
            if(other.Id == Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
