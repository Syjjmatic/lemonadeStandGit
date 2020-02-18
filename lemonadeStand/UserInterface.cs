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
        static string inputError = "Incorrect input. Try again.";
        static string rules = "The rules";
        static string pressEnterToContinue = "\nPress [ENTER] to continue.";

        static public void GameIntroduction()
        {
            Console.WriteLine(welcomeMessage);
            System.Threading.Thread.Sleep(1500);
        }

        static public void DrawStarterMenu()
        {
            Console.Clear();
            Console.WriteLine(starterMenu);
        }

        static public void InputErrorDisplay()
        {
            Console.Clear();
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
            Console.WriteLine(weatherDisplay);
        }
    }
}
