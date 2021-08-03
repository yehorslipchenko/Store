using System;
namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
