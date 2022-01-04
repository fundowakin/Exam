using Exam.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exam.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Ticket>Tickets { get; set; }
        public DbSet<Train>Trains { get; set; }
        public DbSet<Place>Places { get; set; }
        public DbSet<Trip>Trips { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseSqlServer("Server=DESKTOP-GFLE9ES\\MYSQLSERVER;Database=ExamDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().HasKey(x => x.ID);
            modelBuilder.Entity<Ticket>().HasKey(x => x.ID);
            modelBuilder.Entity<Train>().HasKey(x => x.ID);
            modelBuilder.Entity<Trip>().HasKey(x => x.ID);
            modelBuilder.Entity<Customer>().HasKey(x => x.ID);

            modelBuilder.Entity<Trip>().HasData(new Trip[] {
                new Trip{ID = 1, CityOfDeparture = "Kyiv", CityOfArrival = "Poltava", 
                    DateOfArrival = new DateTime(2008, 3, 1, 7, 0, 0), 
                    DateOfDeparture = new DateTime(2008, 3, 1, 7, 0, 0)}
                
            });

            modelBuilder.Entity<Train>().HasData(new Train[] {
                new Train{ID = 1, Name = "InterCity"}

            });

            modelBuilder.Entity<Customer>().HasData(new Customer[] {
                new Customer{ID = 1, Name = "Alice", Password = "scmakascaslmcasm", Login = "Bebrik1337", Surname = "Proshchenko", Balance = 228}

            });

            modelBuilder.Entity<Place>().HasData(new Place[] {
                new Place{ID = 1, Type = true, Status = "Доступний", Number = 1, TrainID = 1},
                new Place{ID = 2, Type = true, Status = "Доступний", Number = 2, TrainID = 1},
                new Place{ID = 3, Type = true, Status = "Доступний", Number = 3, TrainID = 1},
                new Place{ID = 4, Type = true, Status = "Доступний", Number = 4, TrainID = 1},
                new Place{ID = 5, Type = true, Status = "Доступний", Number = 5, TrainID = 1}
            });

            modelBuilder.Entity<Ticket>().HasOne(x => x.Customer)
                .WithMany(y => y.Ticketes).HasForeignKey(k => k.CustomersID);

            modelBuilder.Entity<Ticket>().HasOne(x => x.Trip)
                .WithMany(y => y.Ticketes).HasForeignKey(k => k.TripID);

            modelBuilder.Entity<Ticket>().HasOne(x => x.Place)
                .WithOne(y => y.Ticket).HasForeignKey<Ticket>(k => k.PlaceID);

            modelBuilder.Entity<Place>().HasOne(x => x.Train)
                .WithMany(y => y.Places).HasForeignKey(k => k.TrainID);
        }
    }
}
