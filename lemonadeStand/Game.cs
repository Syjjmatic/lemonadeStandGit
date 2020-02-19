using System;
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
        int itemsToSell;
        int temperature;
        int customerQuantity;
        int customerChanceToBuy;
        int customerPurchased;
        int daysToPlay;
        double playerLemonadePrice;
        double costToPlayer;
        double todayProfit;
        double overallProfit;
        Player player;
        Store store;
        List<Customer> customers;

        public Game()
        {
            player = new Player();
            store = new Store();
            startMenuLoop = true;
            dayCount = 1;
            customers = new List<Customer>();
            playerLemonadePrice = 0;
            customerPurchased = 0;
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
                    daysToPlay = UserInterface.HowManyDaysDoYouWantToPlay();
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

        void CheckForGameOver()
        {
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                if (player.inventory.walletBalance < (player.inventory.items[i].price * (player.inventory.items[i].recipeQuantity - player.inventory.items[i].quantity))
                    && player.inventory.items[i].quantity < player.inventory.items[i].recipeQuantity)
                {
                    UserInterface.GameOver();
                }
            }
        }
        void PlayGameMenuInput()
        {
            Console.Clear();
            CheckForGameOver();

            for (int i = 0; i < daysToPlay; i++)
            {
                playMenuLoop = true;
                Day day = new Day();
                weather = day.weather;
                temperature = day.temperature;

                while (playMenuLoop == true)
                {
                    Console.Clear();
                    UserInterface.WeatherDisplay(dayCount, weather, temperature);
                    UserInterface.DrawPlayMenu();
                    captureInput = Console.ReadLine();
                    while (captureInput != "1" && captureInput != "2" && captureInput != "3" && captureInput != "4" && captureInput != "5" && captureInput != "6" && captureInput != "7")
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
                        SellIngredients();
                    }
                    else if (captureInput == "3")
                    {
                        SetRecipe();
                    }
                    else if (captureInput == "4")
                    {
                        SetLemonadePrice();
                    }
                    else if (captureInput == "5")
                    {
                        for (int j = 0; j < player.inventory.items.Count; j++)
                        {
                            if (playerLemonadePrice == 0)
                            {
                                UserInterface.CantSellWithoutPrice();
                                break;
                            }
                            else if (player.inventory.items[j].recipeQuantity == 0)
                            {
                                UserInterface.CantSellWithoutRecipe();
                                break;
                            }
                            else if (player.inventory.items[j].quantity < player.inventory.items[j].recipeQuantity)
                            {
                                UserInterface.CantSellWithoutItems();
                                break;
                            }
                            else
                            {
                                SellLemonade();
                                playMenuLoop = false;
                                dayCount++;
                                break;
                            }
                        }
                    }
                    else if (captureInput == "6")
                    {
                        ViewInventory();
                    }
                    else if (captureInput == "7")
                    {
                        Environment.Exit(0);
                    }
                }


            }

        }

        void DisplayIngredients(double moneyModifier)
        {
            Console.Clear();
            UserInterface.StoreProductsDisplay();
            for (int i = 0; i < store.items.Count; i++)
            {
                UserInterface.StorePriceDisplay(store.items[i].name.ToUpper(), Math.Round(store.items[i].price * moneyModifier, 2));
            }
        }

        void AddItemsToInventory(int i)
        {
            player.inventory.items[i].quantity += itemsWanted;
        }

        void RemoveItemsFromInventory (int i)
        {
            player.inventory.items[i].quantity -= itemsToSell;
        }

        void RemoveMoneyFromWallet(int i, double moneyModifier)
        {
            player.inventory.walletBalance -= itemsWanted * store.items[i].price * moneyModifier;
        }

        void AddMoneyToWallet(int i, double moneyModifier)
        {
            player.inventory.walletBalance += Math.Round(itemsToSell * store.items[i].price * moneyModifier, 2);
        }

        void BuyIngredients()
        {
            for (int i = 0; i < store.items.Count; i++)
            {
                Console.Clear();
                DisplayIngredients(1);
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                itemsWanted = UserInterface.GetNumberOfItems(store.items[i].name, player.inventory.items[i].quantity);
                while (player.inventory.walletBalance < (itemsWanted * store.items[i].price))
                {
                    Console.Clear();
                    UserInterface.NotEnoughMoneyDisplay();
                    Console.WriteLine(UserInterface.pressEnterToContinue);
                    Console.ReadLine();
                    DisplayIngredients(1);
                    UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                    itemsWanted = UserInterface.GetNumberOfItems(store.items[i].name, player.inventory.items[i].quantity);
                }
                AddItemsToInventory(i);
                RemoveMoneyFromWallet(i, 1);
                
                Console.Clear();
                DisplayIngredients(1);
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                UserInterface.ItemsAddedToInventoryDisplay(player.inventory.items[i].name, itemsWanted);
                Console.WriteLine(UserInterface.pressEnterToContinue);
                Console.ReadLine();
            }
        }

        void SellIngredients()
        {
            for (int i = 0; i < store.items.Count; i++)
            {
                Console.Clear();
                DisplayIngredients(.5);
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                itemsToSell = UserInterface.SellNumberOfItems(store.items[i].name, player.inventory.items[i].quantity);
                while (itemsToSell > player.inventory.items[i].quantity)
                {
                    Console.Clear();
                    Console.WriteLine("You don't have that many items to sell!");
                    Console.WriteLine(UserInterface.pressEnterToContinue);
                    Console.ReadLine();
                    DisplayIngredients(.5);
                    UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                    itemsToSell = UserInterface.SellNumberOfItems(store.items[i].name, player.inventory.items[i].quantity);
                }
                RemoveItemsFromInventory(i);
                AddMoneyToWallet(i, .5);

                Console.Clear();
                DisplayIngredients(.5);
                UserInterface.DisplayWalletBalance(player.inventory.walletBalance);
                UserInterface.ItemsRemovedFromInventoryDisplay(player.inventory.items[i].name, itemsToSell);
                Console.WriteLine(UserInterface.pressEnterToContinue);
                Console.ReadLine();
            }

        }

        void SetRecipe()
        {
            costToPlayer = 0;
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
            }

        }

        void SetLemonadePrice()
        {
            Console.Clear();
            UserInterface.WeatherDisplay(dayCount, weather, temperature);
            playerLemonadePrice = UserInterface.GetPriceOfLemonade(playerLemonadePrice);
        }
        
        void CustomerChanceToBuy()
        {
            if (playerLemonadePrice > 4.00)
            {
                customerChanceToBuy = 0;
            }
            else if (weather == "Sunny" && temperature >= 100)
            {
                if (playerLemonadePrice <= 3.00)
                {
                    customerChanceToBuy = 100;
                }
                else
                {
                    customerChanceToBuy = 90;
                }
            }
            else if ((weather == "Sunny" && temperature >= 90) || (weather == "Cloudy" && temperature >= 100))
            {
                if (playerLemonadePrice <= 2.50)
                {
                    customerChanceToBuy = 90;
                }
                else
                {
                    customerChanceToBuy = 80;
                }
            }
            else if ((weather == "Sunny" && temperature >= 80) || (weather == "Cloudy" && temperature >= 90) || (weather == "Rainy" && temperature >= 100))
            {
                if (playerLemonadePrice <= 2.00)
                {
                    customerChanceToBuy = 90;
                }
                else
                {
                    customerChanceToBuy = 80;
                }
            }
            else if ((weather == "Sunny" && temperature >= 70) || (weather == "Cloudy" && temperature >= 80) || (weather == "Rainy" && temperature >= 90))
            {
                if (playerLemonadePrice <= 2.00)
                {
                    customerChanceToBuy = 80;
                }
                else
                {
                    customerChanceToBuy = 70;
                }
            }
            else if ((weather == "Sunny" && temperature >= 60) || (weather == "Cloudy" && temperature >= 70) || (weather == "Rainy" && temperature >= 80))
            {
                if (playerLemonadePrice <= 1.85)
                {
                    customerChanceToBuy = 80;
                }
                else
                {
                    customerChanceToBuy = 70;
                }
            }
            else if ((weather == "Cloudy" && temperature >= 60) || (weather == "Rainy" && temperature >= 70))
            {
                if (playerLemonadePrice <= 1.50)
                {
                    customerChanceToBuy = 80;
                }
                else
                {
                    customerChanceToBuy = 50;
                }
            }
            else if (weather == "Rainy" && temperature >= 60)
            {
                if (playerLemonadePrice <= 1.25)
                {
                    customerChanceToBuy = 70;
                }
                else
                {
                    customerChanceToBuy = 40;
                }
            }
        }

        void CustomerCreation()
        {
            if (weather == "Sunny" && temperature >= 100)
            {
                customerQuantity = RNG.rng.Next(20, 30);
            }
            else if ((weather == "Sunny" && temperature >= 90) || (weather == "Cloudy" && temperature >= 100))
            {
                customerQuantity = RNG.rng.Next(15, 25);
            }
            else if ((weather == "Sunny" && temperature >= 80) || (weather == "Cloudy" && temperature >= 90) || (weather == "Rainy" && temperature >= 100))
            {
                customerQuantity = RNG.rng.Next(12, 22);
            }
            else if ((weather == "Sunny" && temperature >= 70) || (weather == "Cloudy" && temperature >= 80) || (weather == "Rainy" && temperature >= 90))
            {
                customerQuantity = RNG.rng.Next(10, 20);
            }
            else if ((weather == "Sunny" && temperature >= 60) || (weather == "Cloudy" && temperature >= 70) || (weather == "Rainy" && temperature >= 80))
            {
                customerQuantity = RNG.rng.Next(5, 15);
            }
            else if ((weather == "Cloudy" && temperature >= 60) || (weather == "Rainy" && temperature >= 70))
            {
                customerQuantity = RNG.rng.Next(3, 8);
            }
            else if (weather == "Rainy" && temperature >= 60)
            {
                customerQuantity = RNG.rng.Next(5);
            }

            for (int i = 0; i < customerQuantity; i++)
            {
                customers.Add(new Customer(customerChanceToBuy));
            }
        }

        void CustomerBuysLemonade()
        {
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                player.inventory.items[i].quantity -= player.inventory.items[i].recipeQuantity;
            }
            player.inventory.walletBalance += playerLemonadePrice;
        }

        void CustomerPurchaseDetermination()
        {
            Console.Clear();
            customerPurchased = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                int random = RNG.rng.Next(10);
                if (player.inventory.items[0].quantity < player.inventory.items[0].recipeQuantity ||
                    player.inventory.items[1].quantity < player.inventory.items[1].recipeQuantity ||
                    player.inventory.items[2].quantity < player.inventory.items[2].recipeQuantity ||
                    player.inventory.items[3].quantity < player.inventory.items[3].recipeQuantity)
                {
                    break;
                }
                else if (customerChanceToBuy == 100)
                {
                    CustomerBuysLemonade();
                    customerPurchased++;
                }
                else if (customerChanceToBuy >= 90)
                {
                    if (random > 1)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 80)
                {
                    if (random > 2)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 70)
                {
                    if (random > 3)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 60)
                {
                    if (random > 4)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 50)
                {
                    if (random > 5)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 40)
                {
                    if (random > 6)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
                else if (customerChanceToBuy >= 30)
                {
                    if (random > 7)
                    {
                        CustomerBuysLemonade();
                        customerPurchased++;
                    }
                }
            }
        }

        void SellLemonade()
        {
            CustomerChanceToBuy();
            CustomerCreation();
            CustomerPurchaseDetermination();
            ReportPurchases();
            ReportProfit();
            SpoilIngredients();
        }

        void ReportPurchases()
        {
            Console.Clear();
            Console.WriteLine(customerQuantity + " approached your stand today...\n");
            if (player.inventory.items[0].quantity < player.inventory.items[0].recipeQuantity ||
                player.inventory.items[1].quantity < player.inventory.items[1].recipeQuantity ||
                player.inventory.items[2].quantity < player.inventory.items[2].recipeQuantity ||
                player.inventory.items[3].quantity < player.inventory.items[3].recipeQuantity)
            {
                    Console.WriteLine("You ran out of one or more ingredients throughout the day of sales!\n");
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(customerPurchased + " customers purchased lemonade.\n");
            Console.WriteLine(UserInterface.pressEnterToContinue);
            Console.ReadLine();
        }

        void ReportProfit()
        {
            costToPlayer = (player.inventory.items[0].price * player.inventory.items[0].recipeQuantity) +
                (player.inventory.items[1].price * player.inventory.items[1].recipeQuantity) +
                (player.inventory.items[2].price * player.inventory.items[2].recipeQuantity) +
                (player.inventory.items[3].price * player.inventory.items[3].recipeQuantity);
            Console.Clear();
            todayProfit = (playerLemonadePrice - costToPlayer) * customerPurchased;
            overallProfit += todayProfit;
            Console.WriteLine("Today's cost to you: $" + costToPlayer);
            Console.WriteLine("Today's sale price: $" + playerLemonadePrice + "\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You made $" + todayProfit + " today!");
            Console.WriteLine("You've made a total of $" + overallProfit + " since you started!\n");
            Console.WriteLine(UserInterface.pressEnterToContinue);
            Console.ReadLine();
            customers.Clear();

        }

        void SpoilIngredients()
        {
            Console.Clear();
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                int amountSpoiled;
                amountSpoiled = Convert.ToInt32(Math.Floor(player.inventory.items[i].quantity * .75));
                player.inventory.items[i].quantity -= amountSpoiled;
                Console.WriteLine(amountSpoiled + " of your " + player.inventory.items[i].name + "(s) spoiled!");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
        }

        void ViewInventory()
        {
            Console.Clear();
            Console.WriteLine("PLAYER INVENTORY\n");
            Console.WriteLine("Wallet balance: $" + player.inventory.walletBalance + "\n");
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
            UserInterface.EndGame();
        }
    }
}
