﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadeStand
{
    class Game
    {
        string captureInput;
        string weather;
        bool startMenuLoop;
        bool playMenuLoop;
        int dayCount;
        int itemsWanted;
        int temperature;
        double costToPlayer;
        Player player;
        Store store;

        public Game()
        {
            player = new Player();
            store = new Store();
            startMenuLoop = true;
            playMenuLoop = true;
            dayCount = 1;
        }

        void StarterMenuInput()
        {
            while (startMenuLoop)
            {
                Console.Clear();
                UserInterface.DrawStarterMenu();
                captureInput = Console.ReadLine();
                while (captureInput != "1" && captureInput != "2" && captureInput != "3")
                {
                    Console.Clear();
                    UserInterface.InputErrorDisplay();
                    UserInterface.DrawStarterMenu();
                    captureInput = Console.ReadLine();
                }
                if (captureInput == "1")
                {
                    startMenuLoop = false;
                    PlayGameMenuInput();                    
                }
                else if (captureInput == "2")
                {
                    UserInterface.RulesDisplay();
                }
                else if (captureInput == "3")
                {
                    Environment.Exit(0);
                }
            }
        }

        void PlayGameMenuInput()
        {
            Console.Clear();
            Day day = new Day();
            weather = day.weather;
            temperature = day.temperature;

            while (playMenuLoop == true)
            {
                Console.Clear();
                UserInterface.WeatherDisplay(dayCount, weather, temperature);
                UserInterface.DrawPlayMenu();
                captureInput = Console.ReadLine();
                while (captureInput != "1" && captureInput != "2" && captureInput != "3" && captureInput != "4")
                {
                    Console.Clear();
                    UserInterface.InputErrorDisplay();
                    UserInterface.WeatherDisplay(dayCount, weather, temperature);
                    UserInterface.DrawPlayMenu();
                    captureInput = Console.ReadLine();
                }
                if (captureInput == "1")
                {
                    BuyIngredients();
                }
                else if (captureInput == "2")
                {
                    SetRecipe();
                }
                else if (captureInput == "3")
                {
                    SellLemonade();
                }
                else if (captureInput == "4")
                {
                    ViewInventory();
                }
                else if (captureInput == "5")
                {
                    Environment.Exit(0);
                }
            }
        }

        void DisplayIngredients()
        {
            Console.Clear();
            UserInterface.StoreProductsDisplay();
            for (int i = 0; i < store.items.Count; i++)
            {
                UserInterface.StorePriceDisplay(store.items[i].name.ToUpper(), store.items[i].price);
            }
        }

        void AddItemsToInventory(int i)
        {
            player.inventory.items[i].quantity += itemsWanted;
        }

        void RemoveMoneyFromWallet(int i)
        {
            player.inventory.walletBalance -= (itemsWanted * store.items[i].price);
        }

        void BuyIngredients()
        {
            for (int i = 0; i < store.items.Count; i++)
            {
                Console.Clear();
                DisplayIngredients();
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                itemsWanted = UserInterface.GetNumberOfItems(store.items[i].name);
                while (player.inventory.walletBalance < (itemsWanted * store.items[i].price))
                {
                    Console.Clear();
                    UserInterface.NotEnoughMoneyDisplay();
                    Console.WriteLine(UserInterface.pressEnterToContinue);
                    Console.ReadLine();
                    DisplayIngredients();
                    UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                    itemsWanted = UserInterface.GetNumberOfItems(store.items[i].name);
                }
                AddItemsToInventory(i);
                RemoveMoneyFromWallet(i);
                
                Console.Clear();
                DisplayIngredients();
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                UserInterface.ItemsAddedToInventoryDisplay(player.inventory.items[i].name, itemsWanted);
                Console.WriteLine(UserInterface.pressEnterToContinue);
                Console.ReadLine();
            }
        }

        void SetRecipe()
        {            
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                Console.Clear();
                UserInterface.WeatherDisplay(dayCount, weather, temperature);
                bool userInputIsAnInteger;
                int quantityOfItem;

                if (player.inventory.items[i].name == "cup")
                {
                    i++;
                }
                UserInterface.CreateLemonadeRecipeDisplay(player.inventory.items[i].name);
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
                while (!userInputIsAnInteger || quantityOfItem < 1)
                {
                    Console.Clear();
                    UserInterface.WeatherDisplay(dayCount, weather, temperature);
                    UserInterface.InputErrorDisplay();
                    UserInterface.CreateLemonadeRecipeDisplay(player.inventory.items[i].name);
                    userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
                }
                player.inventory.items[i].recipeQuantity = quantityOfItem;
                costToPlayer += player.inventory.items[i].recipeQuantity * player.inventory.items[i].price;
            }

        }

        void SellLemonade()
        {

        }

        void ViewInventory()
        {
            Console.Clear();
            Console.WriteLine("PLAYER INVENTORY\n");
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                Console.WriteLine(player.inventory.items[i].name.ToUpper() + "S: " + player.inventory.items[i].quantity);
            }
            Console.WriteLine("\n" + UserInterface.pressEnterToContinue);
            Console.ReadLine();
        }

        public void Initialize()
        {
            UserInterface.GameIntroduction();
            StarterMenuInput();
            Console.ReadLine();
        }
    }
}
