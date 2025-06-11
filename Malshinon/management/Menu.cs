using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DAL;

namespace Malshinon.management
{
    public static class Menu
    {

        public static void PrintMenu()
        {
            Console.WriteLine("----- Dashboard Malshinon System -----");
            Console.WriteLine("1. Submit Report");
            Console.WriteLine("2. Import from CSV");
            Console.WriteLine("3. Show Secret Code by Name");
            Console.WriteLine("4. Analysis Dashboard");
            Console.WriteLine("5. Exit");
        }

        public static void Ran()
        {
            PrintMenu();

            string? cho = Console.ReadLine();

            switch (cho)
            {
                case "1":
                    Console.WriteLine("Enter your name:");
                    string? reporterName = Console.ReadLine();

                    Console.WriteLine("Enter target name:");
                    string? targetName = Console.ReadLine();

                    Console.WriteLine("Enter report text:");
                    string? txt = Console.ReadLine();

                    Control.SubmitReport(reporterName, targetName, txt);
                    break;

                case "2":
                    // Import from CSV functionality to be implemented
                    break;

                case "3":
                    Console.WriteLine("Enter full name:");
                    string? fullName = Console.ReadLine();

                    Console.WriteLine(PersonRepository.GetSecretCodeByName(fullName));
                    break;

                case "4":
                    Console.WriteLine("Enter target Id:");
                    string? targetId = Console.ReadLine();

                    AlertRepository.insertAlert(targetId);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }


    }
}
