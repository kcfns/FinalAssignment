using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace FinalAssignment.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Bikes> Bikes { get; set; }
        public DbSet<ServiceParts> ServiceParts { get; set; }
        public DbSet<ServiceRequests> ServiceRequests { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Local");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasData(
                    new Users { Id = 1, Email = "abhishak@gmail.com", Password = "abhishak@123", IsStaff = true },
                    new Users { Id = 2, Email = "piyush@gmail.com", Password = "piyush@123", IsStaff = false },
                    new Users { Id = 3, Email = "bhavdeep@gmail.com", Password = "bhavdeep@123", IsStaff = false },
                    new Users { Id = 4, Email = "kartikay@gmail.com", Password = "kartikay@123", IsStaff = false },
                    new Users { Id = 5, Email = "bhanu@gmail.com", Password = "bhanu@123", IsStaff = true }
                    );
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.Email).IsUnique();

                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Email).IsRequired();
                entity.Property(x => x.Password).IsRequired();

                
            });

            modelBuilder.Entity<Bikes>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasIndex(b => b.BikeNumber).IsUnique();

                entity.Property(b => b.Status).HasDefaultValue(Status.Available);

                //users and bikes realtion
                entity.HasOne(b => b.User)
                .WithMany(u => u.Bikes)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ServiceRequests>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                //bike and ServiceRequest relation
                entity.HasOne(sr => sr.Bike)
                .WithMany(b => b.ServiceRequests)
                .HasForeignKey(st => st.BikeId)
                .OnDelete(DeleteBehavior.Cascade);
            });



            modelBuilder.Entity<ServiceParts>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasIndex(sp => sp.PartNumber).IsUnique();

                entity.Property(sp => sp.Quantity).HasDefaultValue(0);
            });

            modelBuilder.Entity<SystemSettings>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.Property(ss => ss.ServiceFee).HasDefaultValue(500);
            });

        }
    }
}


