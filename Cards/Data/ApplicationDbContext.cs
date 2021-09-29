namespace Cards.Data
{
    using Cards.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Card>()
            //       .HasMany(c => c.UserCards)
            //       .WithMany(u => u.UserId)
            //       .

            //builder.Entity<Cat>()
            //       .HasOne(c => c.User)
            //       .WithMany(u => u.Cats)
            //       .HasForeignKey(c => c.UserId)
            //       .OnDelete(DeleteBehavior.Restrict);
             
            base.OnModelCreating(builder);
        }

    }
}
