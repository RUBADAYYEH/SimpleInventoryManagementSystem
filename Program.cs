﻿using System;

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
