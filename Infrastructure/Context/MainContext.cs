using Infrastructure.DataBase;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class MainContext : DbContext
    {
        protected DbSet<User> Users; 
        protected DbSet<Client> Client; 
        protected DbSet<Order> Orders; 
        protected DbSet<Plate> Plate;
        protected DbSet<Restaurant> Restaurant;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlDataBase.CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
