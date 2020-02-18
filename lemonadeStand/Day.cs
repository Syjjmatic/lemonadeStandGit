using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadeStand
{
    class Day
    {
        public int temperature;
        int rngInt;
        public string weather;
        List<string> weatherList;
        public Day()
        {
            temperature = RNG.rng.Next(60, 110);
            weatherList = new List<string> { "Sunny", "Cloudy", "Rainy"};            
            rngInt = RNG.rng.Next(weatherList.Count);
            weather = Convert.ToString(weatherList[rngInt]);
        }
    }
}
