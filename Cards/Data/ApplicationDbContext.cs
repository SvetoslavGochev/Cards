namespace Cards.Data
{
    using Cards.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
         builder.Entity<Card>()
                .HasOne(c => c.User)
                .WithMany(u => u.)

            base.OnModelCreating(builder);
        }

    }
}
