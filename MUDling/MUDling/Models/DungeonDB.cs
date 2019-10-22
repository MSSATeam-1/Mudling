using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUDling.Models
{
    public class DungeonDB : IdentityDbContext<AppUser>
    {
        public DungeonDB(DbContextOptions<DungeonDB> options) : base(options) { } //uses default ASP.Net options for database configuration
        public DbSet <MUDling.Models.Dungeon> Dungeons { get; set; }
        //public DbSet <AppUser> UserID { get; set; }

    }
}
