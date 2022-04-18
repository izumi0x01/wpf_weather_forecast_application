using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace wpf_weather_forecast_application.model
{
    public enum Condition
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

    internal class Weather
    {
        private List<WeatherModel> one_week_weather = new List<WeatherModel>();

        public List<WeatherModel> One_week_weather
        {
            get
            {
                return one_week_weather;
            }
        }

        private WeatherModel one_day_weather;

        public WeatherModel One_day_weather
        {
            get
            {
                return one_day_weather;
            }
             
        }

        public string tempdata { get; set; }

        public void GetJsonData()
        {
            String url = "https://www.jma.go.jp/bosai/forecast/data/overview_forecast/130000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);
            JObject json = JObject.Parse(reader.ReadToEnd());

            //this.tempdata = json.ToString();
            //Console.WriteLine(json.ToString());

            //one_day_weather.Date = https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json

            var obj_from_json = JObject.Parse(reader.ReadToEnd());
            var forecast_datetime = obj_from_json["weather"]["reportDatetime"];
            var forecast_area = obj_from_json["weather"]["targetArea"];

            this.one_day_weather.area = (string)forecast_area;
            this.one_day_weather.datetime = (string)forecast_datetime;

        }

        public void Get_hukuoka_jsonData()
        {
            String url = "https://www.jma.go.jp/bosai/forecast/data/overview_forecast/400000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);
            JObject json = JObject.Parse(reader.ReadToEnd());

            this.tempdata = json.ToString();
        }
    }

    internal class WeatherModel
    {
        
        //public string Location{ get; set; }

        public double Temperature { get; set; }
        public double Rainy_percent { get; set; }

        public Condition Condition { get; set; }

        public string Date { get; set; }

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public string datetime { get; set; } 
        public string area { get; set; }

    }
}
