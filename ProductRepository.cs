using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleInventoryManagementSystem
{
    internal class ProductRepository
    {
        private string directory = @"C:\users\Lenovo\source\repos\SimpleInventoryManagementSystem\data\";
        private string productsFileName = "products.txt";

        
        public List<Product> LoadProductsFromFile()
        {
            List<Product> products=[];
            string path = $"{directory}{productsFileName}";
            try
            {
                //Check if existing file 
                if (File.Exists(path))
                {
                    string[] productsAsString = File.ReadAllLines(path);
                    foreach (string product in productsAsString)
                    {
                        string[] stringSplit = product.Split(';');
                        bool success = int.TryParse(stringSplit[0], out int productId);
                        if (!success)
                        {
                            productId = 0;
                        }
                        string productName = stringSplit[1];
                        success = int.TryParse(stringSplit[2], out int quantity);
                        if (!success)
                        {
                            quantity = 0;
                        }
                        success = double.TryParse(stringSplit[3], out double price);
                        if (!success)
                        {
                            price = 0.0;
                        }
                        Product newProduct = new Product{
                            ProductId = productId,
                            ProductName= productName,
                            Quantity = quantity,
                            Price =  price 
                        };
                        products.Add(newProduct);

                    }
                }
               

            }catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ResetColor();
            }
            return products;

        }
    }
}
