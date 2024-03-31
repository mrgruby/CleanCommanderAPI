using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Infrastructure.Identity.Persistence
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
           : base(options)
        {
        }

        public DbSet<CommanderUser> CommanderUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthenticationDbContext).Assembly);

            modelBuilder.Entity<CommanderUser>().HasData(new CommanderUser
            {
                UserName= "mrgruby",
                UserId= Guid.Parse("215F392F-CAE9-49A4-B35F-3A1368635E6B"),
                PassWordHash= "$2a$12$wu0EyijSbtbvPADPHqWBBuDfELVqcCruJ4AeKbul6B3U4OtrKGwP."
            });
        }
    }
}
