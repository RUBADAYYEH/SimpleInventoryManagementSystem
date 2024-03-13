using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    internal class Utilities
    {
        private static List<Product> inventory = new();

        internal static void InitializeInventory()
        {
            ProductRepository repository = new ProductRepository();
            inventory = repository.LoadProductsFromFile();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Loaded {inventory.Count} product(s)!");
            Console.WriteLine("Press Any Key To Continue!");
            Console.ResetColor();
            Console.ReadLine();
            
           

        }
        internal static void  ViewMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("* Select an Action *");
            Console.WriteLine("********************");
            Console.WriteLine("1: Inventory management");
            Console.WriteLine("2: Search Panel ");
            Console.WriteLine("3: Save all data");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowInventoryManagementMenu();
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;


            }

        }

        private static void ShowInventoryManagementMenu()
        {
            Console.Clear();
             Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Curret products in inventory: ");
            Console.ForegroundColor= ConsoleColor.Magenta;
            foreach(Product product in inventory)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ResetColor ();
            Console.WriteLine("********************");
            Console.WriteLine("* Select an Action *");
            Console.WriteLine("********************");
            Console.WriteLine("1: Add new Product");
            Console.WriteLine("2: Edit Product ");
            Console.WriteLine("3: Delete Product");
            Console.WriteLine("0: Return to main menu");
            Console.WriteLine("Your selection: ");
            string userAction=Console.ReadLine();
            switch (userAction)
            {
                case "1":
                    AddProduct();
                    
                    break;
                case "2":break;
                case "3":break;
                case "0":break;

            }
        }

        private static void AddProduct()
        {
            Console.WriteLine("Enter the id of the new product: ");
            bool success = int.TryParse(Console.ReadLine(), out int productId);
            if (!success)
            {
                productId = inventory.Where(id=>productId.);
            }
            Console.WriteLine("Enter the name of the new product: ");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the quantity of the new product: ");
             success = int.TryParse(Console.ReadLine(), out int quantity);
            if (!success)
            {
                quantity = 0;
            }
            Console.WriteLine("Enter the price of the new product: ");
             success = double.TryParse(Console.ReadLine(), out double price);
            if (!success)
            {
                price = 0.0;
            }
            Product product = new Product(productId, productName, quantity, price);
            inventory.Add(product);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{productName} ; {productId} added successfully to the inventory");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu");
            Console.ResetColor();

            Console.ReadLine();
            ViewMenu();

        }
    }
}
