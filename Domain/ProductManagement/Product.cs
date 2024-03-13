using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.ProductManagement
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }= string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product() { }
        public Product(int productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
        public override string ToString()
        {
            return $"{ProductId};{ProductName};{Quantity};{Price};";
        }
    }
}
