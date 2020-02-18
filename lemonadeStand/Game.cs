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
        bool startMenuLoop;
        bool playMenuLoop;
        int dayCount;

        public Game()
        {
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
                    UserInterface.InputErrorDisplay();
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
            while (playMenuLoop == true)
            {
                UserInterface.WeatherDisplay(dayCount, day.weather, day.temperature);
                UserInterface.DrawPlayMenu();
                captureInput = Console.ReadLine();
                while (captureInput != "1" && captureInput != "2" && captureInput != "3" && captureInput != "4")
                {
                    UserInterface.InputErrorDisplay();
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

        void BuyIngredients()
        {
            Console.Clear();

        }
        void SetRecipe()
        {

        }
        void SellLemonade()
        {

        }

        void ViewInventory()
        {

        }

        public void Initialize()
        {
            UserInterface.GameIntroduction();;
            StarterMenuInput();
            Console.ReadLine();
        }
    }
}
