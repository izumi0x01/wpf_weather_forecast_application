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

    internal class Data
    {
        public string Location{ get; set; }

        public float Temperature { get; set; }


    }
}
