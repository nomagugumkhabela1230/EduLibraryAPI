
using LibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext>options):base(options) { }


        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<FinePolicy> FinePolicies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Loan>()
           .HasOne(l => l.Member)
           .WithMany(m => m.Loans)
           .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<Loan>()
           .HasOne(l => l.Book)
           .WithMany(b => b.Loans)
           .HasForeignKey(l => l.BookId);


            modelBuilder.Entity<FinePolicy>().HasData(new FinePolicy
            {
                Id = 1,
                DailyFine = 5,
                MaxFinePerLoan = 100
            });
        }

    }

}