using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;

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
        internal static void ViewMenu()
        {
            Console.ResetColor();
            Console.Clear();
            DrawMargins();
            Console.WriteLine("* Select an Action *");
            DrawMargins();
            Console.WriteLine("1: Inventory management");
            Console.WriteLine("2: Search Panel ");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowInventoryManagementMenu();
                    break;
                case "2":
                    SearchForProduct();
                    break;

                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;


            }

        }

        private static void SearchForProduct()
        {
            Console.WriteLine("Search by ID");
            int input = int.Parse(Console.ReadLine()??"0");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Search Results:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(inventory.Find(p => p.ProductId == input));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu");
            Console.ResetColor();

            Console.ReadLine();
            ViewMenu();

        }

        private static void ShowInventoryManagementMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Curret products in inventory: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (Product product in inventory)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ResetColor();
            DrawMargins();
            Console.WriteLine("* Select an Action *");
            DrawMargins();
            Console.WriteLine("1: Add new Product");
            Console.WriteLine("2: Edit Product ");
            Console.WriteLine("3: Delete Product");
            Console.WriteLine("0: Return to main menu");
            Console.WriteLine("Your selection: ");
            string? userAction = Console.ReadLine();
            switch (userAction)
            {
                case "1":
                    AddProduct();

                    break;
                case "2":
                    EditProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "0":
                    ViewMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;


            }
        }

        private static void DeleteProduct()
        {
            Console.WriteLine("Enter the id of the product you want to edit: ");
            int? input = int.Parse(Console.ReadLine()??"0");
            Product? product = inventory.Find(p => p.ProductId == input);
            if (product != null)
            {
                inventory.Remove(product);
                Console.WriteLine($"product with ID {input} has been deleted from the inventory");
            }
            else
            {
                Console.WriteLine($"product with ID {input} does not exist in the inventory");
            }
         
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu");
            Console.ResetColor();

            Console.ReadLine();
            ViewMenu();
        }

        private static void EditProduct()
        {
            Console.WriteLine("Enter the id of the product you want to edit: ");
            int? input = int.Parse(Console.ReadLine() ?? "0");
            Product? product = inventory.Where(p => p.ProductId == input).FirstOrDefault();

            if (product != null)
            {
                DrawMargins();
                Console.WriteLine("Select the data you want to edit: ");
                DrawMargins();
                Console.WriteLine("1: Modify Quantity");
                Console.WriteLine("2: Modify Price ");
                Console.WriteLine("Your selection: ");
                string? userAction = Console.ReadLine();
                switch (userAction)
                {
                    case "1":
                        Console.WriteLine("modify the edited quantity: ");
                        string? quantity = Console.ReadLine();
                        product.Quantity = int.Parse(quantity ?? "0");
                        Console.WriteLine($"{product.ProductName} ; {product.Quantity} modified successfully to the inventory");


                        break;
                    case "2":
                        Console.WriteLine("modify the edited price: ");
                        string? price = Console.ReadLine();
                        product.Price= double.Parse(price ?? "0.0");
                        Console.WriteLine($"{product.ProductName} ; {product.Price} modified successfully to the inventory");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid ID : Product does not exist in the inventory.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu");
            Console.ResetColor();

            Console.ReadLine();
            ViewMenu();
        }

     

        private static void AddProduct()
        {
            Console.WriteLine("Enter the id of the new product: ");
            bool success = int.TryParse(Console.ReadLine(), out int productId);
            if (!success)
            {
                productId = inventory.Max(p => p.ProductId) + 1;
            }
            Console.WriteLine("Enter the name of the new product: ");
            string? productName = Console.ReadLine();
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
            Product product = new Product {ProductId= productId, ProductName=productName,Quantity= quantity,Price= price };
            inventory.Add(product);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{productName} ; {productId} added successfully to the inventory");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu");
            Console.ResetColor();

            Console.ReadLine();
            ViewMenu();

        }
        public static void DrawMargins()
        {
            Console.WriteLine("********************");
        }
    }
}
