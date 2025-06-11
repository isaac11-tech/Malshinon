using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.management
{
    public class Menu
    {
        public void PrintMenu()
        {
            Console.WriteLine("----- Dashboard Malshinon System -----");
            Console.WriteLine("1. Submit Report");
            Console.WriteLine("2. Import from CSV");
            Console.WriteLine("3. Show Secret Code by Name");
            Console.WriteLine("4. Analysis Dashboard");
            Console.WriteLine("5. Exit");

            string cho = Console.ReadLine();

            switch (cho)
            {
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    Console.WriteLine("good by");
                    break; 
                    

            }
        }


    }
}
