﻿using Microsoft.EntityFrameworkCore;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Pez> Peces { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pecera> Peceras { get; set; }
        public DbSet<Filtro> Filtros {  get; set; }
        public DbSet<Aditivo> Aditivos { get; set; }
    }
}
