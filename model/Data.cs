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

    internal class Info
    {
        //public string Location{ get; set; }

        public double Temperature { get; set; }
        public double Rainy_percent { get; set; }

        public Weather Weather { get; set; }

        public string Date { get; set; }

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }


    }
}
