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
        static string rules = "Here are the basic rules in which you will operate:\n\n" +
                "1.) Player sets how many days he/she would like to sell lemonade for.\n" +
                "2.) Player starts with $20.00 to purchase ingredients (lemons, cups, sugar cubes, and ice cubes)\n" +
                "3.) Player brings ingredients to lemonade stand to try and sell lemonade to customers.\n" +
                "4.) Weather and temperature will be set at random for each day of sales. Player sets price of lemonade.\n" +
                "5.) Weather, temperature, and lemonade price will affect a customer's interest in buying lemonade.\n" +
                "6.) The more lemonade the stand is able to sell, the more successful the player's business is.\n" +
                "7.) If player runs out of money, player loses.\n";
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

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Welp, it looks like you made it to the end.\n" +
                "Congrats to you, you do-gooder.\n\n" +
                "Now get outta here, ya filthy animal.\n");
            Console.WriteLine("Press [ENTER] to exit.");
            Console.ReadLine();
            Environment.Exit(0);

        }

        public static void CantSellWithoutPrice()
        {
            Console.Clear();
            Console.WriteLine("You can't start selling until you've set a price for your lemonade!\n");
            Console.WriteLine(pressEnterToContinue);
            Console.ReadLine();
        }

        public static void CantSellWithoutRecipe()
        {
            Console.Clear();
            Console.WriteLine("You can't start selling until you've set a recipe!\n");
            Console.WriteLine(pressEnterToContinue);
            Console.ReadLine();
        }

        public static void CantSellWithoutItems()
        {
            Console.Clear();
            Console.WriteLine("You don't have enough items to start selling! Head to the store to buy more!\n");
            Console.WriteLine(pressEnterToContinue);
            Console.ReadLine();
        }

        public static int HowManyDaysDoYouWantToPlay()
        {
            bool userInputIsAnInteger;
            int daysToPlay;

            Console.Clear();
            Console.WriteLine("How many days do you want to play?");
            userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out daysToPlay);

            while (!userInputIsAnInteger || daysToPlay < 1 || daysToPlay > Int32.MaxValue)
            {
                Console.Clear();
                InputErrorDisplay();
                Console.WriteLine("How many days do you want to play?");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out daysToPlay);
            }

            return daysToPlay;
        }

        public static void GameOver()
        {
            Console.WriteLine("You are unable to purchase sufficient ingredients to continue selling.\n" +
                "Your business has failed.\n\n" +
                "GAME OVER.\n");
            Console.WriteLine("Press [ENTER] to exit.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
