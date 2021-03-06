// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NbaShopService.Models
{
    public partial class nbashopContext : DbContext
    {
        public nbashopContext()
        {
        }

        public nbashopContext(DbContextOptions<nbashopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Jersey> Jersey { get; set; }
        public virtual DbSet<Shorts> Shorts { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Viewcustomerproducts> Viewcustomerproducts { get; set; }
        public virtual DbSet<Viewjerseytype> Viewjerseytype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=nbashop;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasIndex(e => e.Date, "cart_date_uindex")
                    .IsUnique();

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.Products)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.BuyDateNavigation)
                    .WithMany(p => p.CustomerBuyDateNavigation)
                    .HasPrincipalKey(p => p.Date)
                    .HasForeignKey(d => d.BuyDate)
                    .HasConstraintName("customer_cart_date_fk");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.CustomerCustomerNavigation)
                    .HasForeignKey<Customer>(d => d.CustomerId)
                    .HasConstraintName("customer_cart_cartid_fk");
            });

            modelBuilder.Entity<Jersey>(entity =>
            {
                entity.Property(e => e.JerseyId)
                    .ValueGeneratedNever()
                    .HasColumnName("JerseyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Shorts>(entity =>
            {
                entity.Property(e => e.ShortsId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShortsID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.Name, "team_name_uindex")
                    .IsUnique();

                entity.Property(e => e.TeamId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeamID");

                entity.Property(e => e.Away).HasColumnType("character varying");

                entity.Property(e => e.Coast).HasColumnType("character varying");

                entity.Property(e => e.Home).HasColumnType("character varying");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Viewcustomerproducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewcustomerproducts");

                entity.Property(e => e.Email).HasColumnType("character varying");

                entity.Property(e => e.Firstname).HasColumnType("character varying");

                entity.Property(e => e.LastName).HasColumnType("character varying");

                entity.Property(e => e.Location).HasColumnType("character varying");

                entity.Property(e => e.Products).HasColumnType("character varying");
            });

            modelBuilder.Entity<Viewjerseytype>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewjerseytype");

                entity.Property(e => e.Firstname).HasColumnType("character varying");

                entity.Property(e => e.LastName).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}