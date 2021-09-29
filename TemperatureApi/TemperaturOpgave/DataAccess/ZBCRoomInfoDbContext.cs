using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturOpgave.DataAccess
{
    public class ZBCRoomInfoDbContext : DbContext
    {
        public ZBCRoomInfoDbContext(DbContextOptions options) : base (options)
        {
            Database.Migrate();
        }
    }
}
