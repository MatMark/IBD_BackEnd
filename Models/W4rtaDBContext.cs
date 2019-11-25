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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Investment> Investment { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:w4rta-host.database.windows.net,1433;Initial Catalog=W4rtaDB;Persist Security Info=False;User ID=Bird;Password=roman-IBD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESSES");

                entity.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("ID");

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

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENTS");

                entity.Property(e => e.Id)
                .HasColumnName("ID")
                .IsRequired();

                entity.Property(e => e.FirstName)
                .HasColumnName("FIRST_NAME")
                .IsRequired()
                .HasColumnType("text");

                entity.Property(e => e.LastName)
               .HasColumnName("LAST_NAME")
               .IsRequired()
               .HasColumnType("text");

                entity.Property(e => e.Pesel)
               .HasColumnName("PESEL")
               .IsRequired()
               .HasColumnType("text");

                entity.Property(e => e.Phone)
               .HasColumnName("PHONE")
               .IsRequired()
               .HasColumnType("text");

                entity.Property(e => e.Email)
               .HasColumnName("EMAIL")
               .IsRequired()
               .HasColumnType("text");

                entity.Property(e => e.BirthDate)
               .HasColumnName("BIRTH_DATE")
               .IsRequired()
               .HasColumnType("date");

                entity.Property(e => e.Password)
               .HasColumnName("PASSWORD")
               .IsRequired()
               .HasColumnType("text");

                entity.Property(e => e.AddressId)
               .HasColumnName("ADDRESS_ID")
               .IsRequired()
               .HasColumnType("int");

                entity.HasOne(d => d.Address)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ADDRESS_ID");
            });
            modelBuilder.Entity<Investment>(entity =>
            {
                entity.ToTable("INVESTMENTS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.Interest)
                    .HasColumnName("INTEREST")
                    .IsRequired()
                    .HasColumnType("real");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.Deadline)
                    .HasColumnName("DEADLINE")
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.AccountId)
                    .HasColumnName("ACCOUNT_ID")
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasOne(e => e.Account)
                    .WithMany(d => d.Investments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACCOUNT_ID");

            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.ToTable("TRANSFERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("TIME");

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

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("ACCOUNT_ID")
                    .HasColumnType("int");

                entity.Property(e => e.AddressId)
                    .IsRequired()
                    .HasColumnName("ADDRESS_ID")
                    .HasColumnType("int");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("CURRENCY")
                    .HasColumnType("text");     
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNTS");

                entity.Property(e => e.Id)
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

                entity.HasOne(e => e.Client)
                    .WithMany(d => d.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENT_ID");

            });
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("LOANS");

                entity.Property(e => e.Id)
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

                entity.HasOne(e => e.Account)
                    .WithMany(d => d.Loans)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACCOUNT_ID");
            });


        }
    }
}
