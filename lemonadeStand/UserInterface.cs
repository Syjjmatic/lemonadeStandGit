using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadeStand
{
    static class UserInterface
    {
        static string welcomeMessage = "Welcome to Lemonade Stand!";
        static string starterMenu = "What would you like to do?\n" +
            "1.) Play\n" +
            "2.) See rules\n" +
            "3.) Exit";
        static string playMenu = "What would you like to do?\n" +
            "1.) Buy ingredients\n" +
            "2.) Sell ingredients\n" +
            "3.) Set/change recipe\n" +
            "4.) Set lemonade price\n" +
            "5.) Go to your stand and sell\n" +
            "6.) View your inventory\n" +
            "7.) Exit";
        static string inputError = "Incorrect input. Try again.\n";
        static string rules = "The rules";
        static public string pressEnterToContinue = "Press [ENTER] to continue.";

        static public void GameIntroduction()
        {
            Console.WriteLine(welcomeMessage);
            System.Threading.Thread.Sleep(1500);
        }

        static public void DrawStarterMenu()
        {
            Console.WriteLine(starterMenu);
        }

        static public void InputErrorDisplay()
        {
            Console.WriteLine(inputError);
        }

        static public void RulesDisplay()
        {
            Console.Clear();
            Console.WriteLine(rules);
            Console.WriteLine(pressEnterToContinue);
            Console.ReadLine();
        }

        static public void HowManyDays()
        {
            string howManyDays = "How many days do you want to play?";
            Console.WriteLine(howManyDays);
        }

        static public void WeatherDisplay(int dayInt, string weather, int temperature)
        {
            string weatherDisplay = "Day " + dayInt + ": " + weather + ", " + temperature;
            Console.WriteLine(weatherDisplay + "\n");
        }

        static public void DrawPlayMenu()
        {
            Console.WriteLine(playMenu);
        }

        static public void StoreProductsDisplay()
        {
            string buyIngredients = "THE STORE\n\n" +
                "Available products:\n";
            Console.WriteLine(buyIngredients);
        }

        public static int GetNumberOfItems(string itemsToGet, int currentQuantity)
        {
            bool userInputIsAnInteger;
            int quantityOfItem;

            Console.WriteLine("\nHow many " + itemsToGet + "s would you like to buy? (Current quantity: " + currentQuantity + ")");
            userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.Clear();
                InputErrorDisplay();
                Console.WriteLine("How many " + itemsToGet + "s would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static void ItemsAddedToInventoryDisplay(string name, int amount)
        {
            string howManyItemsAdded = "\n" + amount + " " + name + "(s) were added to your inventory!";
            Console.WriteLine(howManyItemsAdded);
        }

        public static void ItemsRemovedFromInventoryDisplay(string name, int amount)
        {
            string howManyItemsAdded = "\n" + amount + " " + name + "(s) were removed from your inventory!";
            Console.WriteLine(howManyItemsAdded);
        }

        public static void DisplayWalletBalance(double balance)
        {
            Console.WriteLine("\nAVAILABLE BALANCE: $" + balance);
        }

        public static void NotEnoughMoneyDisplay()
        {
            Console.WriteLine("You don't have enough money to do that!\n");
        }

        public static void CreateLemonadeRecipeDisplay(string name)
        {
            Console.WriteLine("Create lemonade recipe:\n\n" +
                "How many " + name + "s are in a cup of lemonade?");

        }

        public static void StorePriceDisplay(string name, double price)
        {
            Console.WriteLine(name + ": $" + price);
        }

        public static double GetPriceOfLemonade(double priceOfLemonade)
        {
            bool userInputIsADouble;
            double quantityOfItem;

            Console.WriteLine("Current set price: $" + priceOfLemonade);
            Console.WriteLine("How much would you like to charge for a cup of lemonade?");
            userInputIsADouble = double.TryParse(Console.ReadLine(), out quantityOfItem);

            while (!userInputIsADouble || quantityOfItem < 1)
            {
                Console.Clear();
                InputErrorDisplay();
                Console.WriteLine("Current set price: " + priceOfLemonade);
                Console.WriteLine("\nHow much would you like to charge for a cup of lemonade?");
                Console.WriteLine("Please enter a positive integer greater than 0:");

                userInputIsADouble = double.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static int SellNumberOfItems(string itemsToGet, int currentQuantity)
        {
            bool userInputIsAnInteger;
            int quantityOfItem;

            Console.WriteLine("\nHow many " + itemsToGet + "s would you like to sell? (Current quantity: " + currentQuantity + ")");
            userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.Clear();
                InputErrorDisplay();
                Console.WriteLine("How many " + itemsToGet + "s would you like to sell?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }
    }
}
