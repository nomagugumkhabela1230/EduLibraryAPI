
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) {}
        

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Fine> Fines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .Property(b => b.AvailableCopies)
                .HasDefaultValue(0);

            modelBuilder.Entity<Loan>()
        .HasOne(l => l.Member)
        .WithMany(m => m.Loans)
        .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<Member>()
           .HasOne(m => m.User)
           .WithMany()
           .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Fine)
                .WithOne(f => f.Loan)
                .HasForeignKey<Fine>(f => f.LoanId);

         modelBuilder.Entity<Fine>()
        .Property(f => f.Amount)
        .HasColumnType("decimal(18,2)");


        


        }

    }

}