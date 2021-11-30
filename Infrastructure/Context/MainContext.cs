using Infrastructure.DataBase;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class MainContext : DbContext
    {
        DbSet<User> Users; 
        DbSet<Client> Client; 
        DbSet<Order> Orders; 
        DbSet<Plate> Plates;
        DbSet<Restaurant> Restaurants;
        DbSet<Category> Categories;

        //public MainContext(DbSet<User> users, DbSet<Client> clients, DbSet<Order> orders, DbSet<Plate> plates, DbSet<Restaurant> restaurants, DbSet<Category> categories)
        //{
        //    Users = users;
        //    Client = clients;
        //    Orders = orders;
        //    Plates = plates;
        //    Restaurants = restaurants;
        //    Categories = categories;
        //}

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

