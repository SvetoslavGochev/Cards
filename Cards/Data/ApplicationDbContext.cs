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

        public DbSet<Cat> Cats { get; init; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<UserCard> UsersCards { get; set; }
        public DbSet<AA> ASs { get; set; }
        public DbSet<BB> BBs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCard>()
         .HasKey(bc => new { bc.UserId, bc.CardId });


            //builder.Entity<UserCard>()
            //    .HasOne(bc => bc.User)
            //    .WithMany(b => b.Cards)
            //    .HasForeignKey(bc => bc.CardId);
            //builder.Entity<UserCard>()
            //    .HasOne(bc => bc.Card)
            //    .WithMany(c => c.Users)
            //    .HasForeignKey(bc => bc.UserId);


            //builder.Entity<Cat>()
            //       .HasOne(c => c.User)
            //       //vsqka kotka ima edin user
            //       .WithMany(u => u.Cats)
            //       //vseki user ima mnogo kotki
            //       .HasForeignKey(c => c.UserId)
            //       //vsqka kotka ima foreing key
            //       .OnDelete(DeleteBehavior.Restrict);

            //builder
            //   .Entity<Dealer>()
            //   .HasOne<User>()
            //   .WithOne()
            //   .HasForeignKey<Dealer>(d => d.UserId)
            //   .OnDelete(DeleteBehavior.Restrict);
            //kato iztriem edin dilar da ne se trie usera
            //vrazvame kam tablica user
            base.OnModelCreating(builder);
        }

    }
}
