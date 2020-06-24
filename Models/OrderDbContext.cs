using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tut12.Models
{
    public class OrderDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DbSet<Confectionery> Confectioneries { get; set; }

        public DbSet<Confectionery_Order> Confectionery_Orders { get; set; }

        public OrderDbContext()
        {

        }

        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confectionery_Order>().HasKey(x => new { x.IdConfectionary, x.IdOrder });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(opt =>
            {

                opt.HasKey(p => p.IdEmployee);
                opt.Property(p => p.IdEmployee)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                opt.Property(p => p.Surname)
                .HasMaxLength(60)
                .IsRequired();

            });
            modelBuilder.Entity<Order>(opt =>
            {

                opt.HasKey(p => p.IdOrder);
                opt.Property(p => p.IdOrder)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Notes)
                .HasMaxLength(255)
                .IsRequired();

                opt.HasOne(p => p.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.IdOrder);

                opt.HasOne(p => p.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.IdOrder);
            });
            modelBuilder.Entity<Customer>(opt =>
            {

                opt.HasKey(p => p.IdCustomer);
                opt.Property(p => p.IdCustomer)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                opt.Property(p => p.Surname)
                .HasMaxLength(60)
                .IsRequired();

            });
            modelBuilder.Entity<Confectionery_Order>(opt =>
            {

                opt.HasKey(p => p.IdConfectionary);
                opt.Property(p => p.IdConfectionary)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Quantity)
                .IsRequired();

                opt.Property(p => p.Notes)
                .HasMaxLength(255)
                .IsRequired();

                opt.HasOne(p => p.Order)
                .WithMany(p => p.Confectionery_Orders)
                .HasForeignKey(p => p.IdConfectionary);
            });

            modelBuilder.Entity<Confectionery>(opt =>
            {
                
                opt.HasKey(p => p.IdConfectionery);
                opt.Property(p => p.IdConfectionery)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

                opt.Property(p => p.PricePerItem)
                .IsRequired();

                opt.Property(p => p.Type)
                .HasMaxLength(40)
                .IsRequired();

            });

        }
    }
}
