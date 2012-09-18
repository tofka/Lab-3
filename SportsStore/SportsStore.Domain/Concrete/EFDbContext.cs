﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SportsStore.Domain.Entities;
using SportsStore.Model.Entities;

namespace SportsStore.Domain.Concrete {
    public class EFDbContext : DbContext {
        public DbSet<Product> Products {
            get;
            set;
        }
    }

    public class SportsStoreInitializer : DropCreateDatabaseIfModelChanges<EFDbContext> {
        protected override void Seed(EFDbContext context) {
            
            var products = new List<Product> {
                new Product { ProductID = 1, Name = @"Kayak", Description = @"A boat for one person", Price = 275M, Category = @"Watersport" },
                new Product { ProductID = 2, Name = @"Lifejacket", Description = @"Protective and fashionable", Price = 48.95M, Category = @"Watersport"},
                new Product { ProductID = 3, Name = @"Soccer ball", Description = @"FIFA-approved size and weight", Price = 19.5M, Category = @"Soccer" },
                new Product { ProductID = 3, Name = @"Soccer ball", Description = @"FIFA-approved size and weight", Price = 19.5M, Category = @"Soccer"},
                new Product { ProductID = 4, Name = @"Corner flags", Description = @"Give your playing field that professional touch", Price = 34.95M, Category = @"Soccer" },
                new Product { ProductID = 5, Name = @"Stadium", Description = @"Flat-packed 35,000 seat stadium", Price = 79500M, Category = @"Soccer" },
                new Product { ProductID = 6, Name = @"Thinking cap", Description = @"Improve your brain efficiency by 75%", Price = 16.0M, Category = @"Chess"},
                new Product { ProductID = 7, Name = @"Unsteady chair", Description = @"Secretly give your opponent a disadvantage", Price = 29.95M, Category = @"Chess" },
                new Product { ProductID = 8, Name = @"Human Chess Board", Description = @"A fun game for the whole family", Price = 75.00M, Category = @"Chess"},
                new Product { ProductID = 9, Name = @"Bling-bling King", Description = @"Gold-plated, diamond-studded King", Price = 275M, Category = @"Chess" },

            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}