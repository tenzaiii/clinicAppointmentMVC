using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using clinicAppointmentMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace clinicAppointmentMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any custom configurations here
        }
    }
}
