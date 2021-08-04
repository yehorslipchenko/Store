using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Data;

namespace Store.Models
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Order> GetOrders();

        Task AddProductAsync(Product product);
        Task AddOrderAsync(Order order);

        Task UpdateProductAsync(Product product);
        Task UpdateOrderAsync(Order order);

        Task DeleteProductAsync(Product product);
        Task DeleteOrderAsync(Order order);

        Product FindProduct(int id);
        Order FindOrder(int id);
    }
}
