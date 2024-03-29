﻿using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        // this constructor enables the MovieDbContext class to receive configuration options that determine how it interacts with the underlying database
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
           : base(options)
        {

        }
        
        private static void NewMethod(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CleanMovieDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many (Member and Rentals)
            modelBuilder.Entity<Member>()
                 .HasOne<Rental>(s => s.Rental)
                 .WithMany(r => r.Members)
                 .HasForeignKey(s => s.RentalId);

            //Many to Many (Rental and Movie)
            modelBuilder.Entity<MovieRental>()
                .HasKey(g => new { g.RentalId, g.MovieId });

            //Handle Decimals to avoid precision loss

            modelBuilder.Entity<Rental>()
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Movie>()
               .Property(p => p.RentalCost)
               .HasColumnType("decimal(18,2)");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }


    }
}
