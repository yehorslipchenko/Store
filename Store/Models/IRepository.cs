using System;
using System.Collections.Generic;
using Store.Data;

namespace Store.Models
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Order> GetOrders();

        void AddProduct(Product product);
        void AddOrder(Order order);

        void UpdateProduct(Product product);
        void UpdateOrder(Order order);

        void DeleteProduct(Product product);
        void DeleteOrder(Order order);

        Product FindProduct(int id);
        Order FindOrder(int id);
    }
}
