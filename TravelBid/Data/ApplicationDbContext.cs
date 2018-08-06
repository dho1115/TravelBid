using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBid.Models;

namespace TravelBid.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<VacationDetails> newvacationrequest { get; set; } //creates a new property and will be the name of the new table under ApplicationDBContext after you enter 'Add-Migration VacationDetails' in the Package Manager console.

        public DbSet<TravelAgentParameters> TravelAgentParameters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
