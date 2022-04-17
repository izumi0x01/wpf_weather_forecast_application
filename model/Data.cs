using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_weather_forecast_application.model
{
    public enum Weather
    {
        sunny,
        cloud,
        rain,
        snow
    }
    public enum Location
    {
        tokyo = 0,
        hokkaido  = 1,
        hukuoka = 2,
    }

    internal class Data
    {
        //public string Location{ get; set; }

        public double Temperature { get; set; }
        public double Rainy_percent { get; set; }

        public Weather Weather { get; set; }

        public string Date { get; set; }

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public string testdata { get; set; }
    }
}
