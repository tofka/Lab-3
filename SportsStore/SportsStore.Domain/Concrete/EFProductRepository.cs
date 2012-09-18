using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Abstract;
using System.Data;

namespace SportsStore.Domain.Repositories {
    public class EFProductRepository : IProductRepository {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products {
            get {
                return context.Products;
            }
        }
        public void Add(Product p) {
            context.Products.Add(p);
            context.SaveChanges();
        }
        public void Edit(Product p) {
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Product p) {
            context.Entry(p).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public Product Get(int id) {
            return Products.Where(p => p.ProductID == id).FirstOrDefault();
        }
        public void SaveProduct(Product product) {
            if (product.ProductID == 0) {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
        public void DeleteProduct(Product product) {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}