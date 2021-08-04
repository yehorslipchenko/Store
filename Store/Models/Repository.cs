using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Data;

namespace Store.Models
{
    public class Repository : IRepository
    {
        private StoreDbContext db;

        public Repository(StoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetProducts() => db.Products.ToList();

        public IEnumerable<Order> GetOrders() => db.Orders.ToList();


        public async Task AddProductAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }



        public async Task UpdateProductAsync(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
        }


        public async Task DeleteProductAsync(Product product)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
        }

        public Product FindProduct(int id) => db.Products.Find(id);

        public Order FindOrder(int id) => db.Orders.Find(id);

    }
}
