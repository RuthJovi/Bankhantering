using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bankhantering.Bank;

namespace Bankhantering
{
    public class Manage_customers
    {
        /*
        public void ManageCustomers()
        {
            List<Customer> customers = new List<Customer>();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("MANAGE CUSTOMERS");
                Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
                Console.WriteLine("What would you like to do with the customers?");
                Console.WriteLine("1. View customers");
                Console.WriteLine("2. Add a new customer");
                Console.WriteLine("3. Remove a customer");
                Console.WriteLine("4. Return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Bank a = new Bank();
                        a.PrintCustomers(customers);
                        break;
                    case "2":
                        Bank b = new Bank();
                        b.AddCustomer(customers);
                        b.PrintCustomers(customers);
                        break;
                    case "3":
                        Bank c = new Bank();
                        c.RemoveCustomer(customers);

                        break;
                    case "4":
                        Bank bank = new Bank();
                        bank.MainMenu();
                        break;
                }
            }
        }
        */
    }
}
