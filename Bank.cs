using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankhantering
{
    public class Bank
    {
        List<Customer> customers = new List<Customer>();
        public class Customer
        {
            public string name; public int money; //every user has a name and account balance
            public Customer(string newName, int newMoney) 
            {
                name = newName; money = newMoney;
            }
        }
        public void MainMenu()
        {
            bool running = true;
            while (running) 
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU"); Console.WriteLine();
                Console.WriteLine("Welcome to the bank?\n" + "WHat would you like to do?\n" + "1. Manage customers\n" + "2. Manage accounts");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ManageCustomers();
                        break;
                    case "2":
                        Console.Clear();
                        ManageAccounts();
                        break;
                }
            }
        } //the main menu, where the user can choose "manage customers" or "manage accounts"
        public void PressToContinue()
        {
            Console.ReadKey(); Console.WriteLine("Press to continue");
        }  
        public void PrintCustomers(List<Customer> list)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"CUSTOMER {i + 1} - Name: {list[i].name} || Balance: {list[i].money} SEK");
            }
        } //prints an ordered list of the customers, along with their name and money


        public void ManageCustomers()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("MANAGE CUSTOMERS");
                Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
                Console.WriteLine("What would you like to do with the customers?\n" + "1. View customers\n" + "2. Add a new customer\n" + "3. Remove a customer\n" + "4. Return to main menu");
                switch (Console.ReadLine())
                {
                    case "1":
                        PrintCustomers(customers);
                        PressToContinue();
                        break;
                    case "2":
                        ;
                        AddCustomer(customers);
                        
                        break;
                    case "3":
                        RemoveCustomer(customers);

                        break;
                    case "4":
                        MainMenu();
                        break;
                }
            }
        } //the menu for "manage customers"

        //functions that are accessed from the "manage customers" menu
        public void AddCustomer(List<Customer> list)
        {
            Console.WriteLine("Add a name for the new customer:");
            Customer newCustomer = new Customer(Console.ReadLine(), 0);
            Console.WriteLine($"How much money should {newCustomer.name} start out with?");
            newCustomer.money = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{newCustomer.name} was added with {newCustomer.money} crowns in their account.");
            list.Add(newCustomer); PrintCustomers(list); PressToContinue();
        } //allows the user to add a customer to the list
        public void RemoveCustomer(List<Customer> list)
        {
            PrintCustomers(list); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Which customer do you wish to remove? Answer with the customers index:");
            list.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1); //removes the object at the chosen index, removes 1 since lists start at 0
            PrintCustomers(list); PressToContinue();
        }  //allows the user to remove a customer by index


        public void ManageAccounts()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("MANAGE ACCOUNTS");
                Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
                Console.WriteLine("What would you like to do with the accounts?");
                Console.WriteLine("1. Add/remove money from an account");
                Console.WriteLine("2. Transfer money between two accounts");
                Console.WriteLine("3. Return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ChangeMoney(customers);
                        break;
                    case "2":
                        TransferMoney(customers);
                        break;
                    case "3":
                        MainMenu();
                        break;
                }
            }
        } //the menu for "manage accounts"

        //functions that are accessed from the "manage accounts" menu
        public void ChangeMoney(List<Customer> list)
        {
            PrintCustomers(list); Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine("Which account do you wish to alter? Answer with the customers index:"); 
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine($"How much money do you wish to add/remove from {list[index].name}'s account? Ex: Entering 40 equals +40, -60 equals -60");
            int change = Convert.ToInt32(Console.ReadLine()); list[index].money = list[index].money + change;
            PrintCustomers(list); PressToContinue();
        }  //allows the user to add/remove money from a single account
        public void TransferMoney(List<Customer> list)
        {
            PrintCustomers(list); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Which customer do you wish to take money from? Answer with the customers index:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine($"How much money do you want to take from {list[index].name}'s account?");
            int change = Convert.ToInt32(Console.ReadLine()); list[index].money = list[index].money - change;
            Console.WriteLine("Now choose a customer to deposit the money to:");
            int index2 = Convert.ToInt32(Console.ReadLine()) - 1; list[index2].money = list[index2].money + change;
            PrintCustomers(list); PressToContinue();
        } //allows the user to transfer money between two accounts
    }
}
