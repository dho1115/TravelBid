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
        public DbSet<VacationerModel> NewVacationerModel { get; set; }

        public DbSet<DestinationRequest> DestinationRequests { get; set; } //Right now, this will error b/c DestinationRequest has no id.

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<DestinationRequest>().HasKey("name"); // <= This catches errors @ run-time, so if you do not have a "name" property inside the model, it will not catch it.

            //OR
           
            builder.Entity<DestinationRequest>().HasKey(x => x.name); // <=This catches errors @ compile time. 

            builder.Entity<DestinationRequest>().Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Entity<DestinationRequest>().Property(x => x.DateModified).HasDefaultValue(DateTime.Now);
            builder.Entity<DestinationRequest>().Property(x => x.name).HasMaxLength(100);
        }
    }
}
