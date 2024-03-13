using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to Simple Inventory Management System!");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            Utilities.InitializeInventory();
            Utilities.ViewMenu();
        }
    }
}
