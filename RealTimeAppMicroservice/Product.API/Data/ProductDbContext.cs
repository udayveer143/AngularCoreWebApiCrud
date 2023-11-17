﻿using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.DTO;

namespace Product.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
