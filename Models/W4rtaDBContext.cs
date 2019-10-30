using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class W4rtaDBContext : DbContext
    {
        public W4rtaDBContext()
        {
        }

        public W4rtaDBContext(DbContextOptions<W4rtaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:w4rta-host.database.windows.net,1433;Initial Catalog=W4rtaDB;Persist Security Info=False;User ID=Bird;Password=roman-IBD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("ADDRESSES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApartmentNumber).HasColumnName("APARTMENT_NUMBER");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("text");

                entity.Property(e => e.HomeNumber).HasColumnName("HOME_NUMBER");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasColumnName("POST_CODE")
                    .HasColumnType("text");

                entity.Property(e => e.Street)
                    .HasColumnName("STREET")
                    .HasColumnType("text");
            });

        }
    }
}
