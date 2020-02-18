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
        bool keepLoop;
        int dayCount;

        public Game()
        {
            keepLoop = true;
            dayCount = 1;
        }

        void StarterMenuInput()
        {
            while (keepLoop == true)
            {
                UserInterface.DrawStarterMenu();
                captureInput = Console.ReadLine();
                while (captureInput != "1" && captureInput != "2" && captureInput != "3")
                {
                    UserInterface.InputErrorDisplay();
                }
                if (captureInput == "1")
                {
                    keepLoop = false;
                    PlayGame();                    
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

        void PlayGame()
        {
            Console.Clear();
            Day day = new Day();
            UserInterface.WeatherDisplay(dayCount, day.weather, day.temperature);

        }

        public void Initialize()
        {
            UserInterface.GameIntroduction();
            UserInterface.DrawStarterMenu();
            StarterMenuInput();
            Console.ReadLine();
        }
    }
}
