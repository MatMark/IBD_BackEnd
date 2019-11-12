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
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Loans> Loans { get; set; }

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

            modelBuilder.Entity<Transfers>(entity =>
            {
                entity.ToTable("TRANSFERS");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("TIME")
                    .HasColumnType("date");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("DESTINATION_ACCOUNT_NUMBER")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE")
                    .HasColumnType("text");

                entity.Property(e => e.AddressId)
                    .HasColumnName("ADDRESS_ID")
                    .HasColumnType("int");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("ACCOUNT_ID")
                    .HasColumnType("int");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("CURRENCY")
                    .HasColumnType("text");     
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("ACCOUNTS");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("NUMBER")
                    .HasColumnType("text");

                entity.Property(e => e.Balance)
                    .IsRequired()
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("CLIENT_ID")
                    .HasColumnType("int");
            });
            modelBuilder.Entity<Loans>(entity =>
            {
                entity.ToTable("LOANS");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.Interest)
                    .IsRequired()
                    .HasColumnName("INTEREST")
                    .HasColumnType("double");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Deadline)
                    .IsRequired()
                    .HasColumnName("DEADLINE")
                    .HasColumnType("date");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("ACCOUNT_ID")
                    .HasColumnType("int");
            });


        }
    }
}
