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

        public Game()
        {

        }

        void InputDecision()
        {
            while (true)
            {
                UserInterface.DrawStarterMenu();
                captureInput = Console.ReadLine();
                while (captureInput != "1" && captureInput != "2" && captureInput != "3")
                {
                    UserInterface.InputError();
                }
                if (captureInput == "1")
                {
                    PlayGame();
                }
                else if (captureInput == "2")
                {
                    UserInterface.Rules();
                }
                else if (captureInput == "3")
                {
                    Environment.Exit(0);
                }
            }
        }

        void PlayGame()
        {

        }

        public void Initialize()
        {
            UserInterface.GameIntroduction();
            UserInterface.DrawStarterMenu();
            InputDecision();
            Console.ReadLine();
        }
    }
}
