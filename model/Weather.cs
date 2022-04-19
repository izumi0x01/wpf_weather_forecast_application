using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;


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
        hokkaido = 1,
        hukuoka = 2,
    }

    internal class Weather
    {

        private WeatherModel one_day_weather;

        public WeatherModel One_day_weather { get; set; }

        private WeatherModel[] _Weekly_Weather;

        public WeatherModel[] Weekly_Weather { get { return _Weekly_Weather; } }

        public Weather()
        {
            _Weekly_Weather = new WeatherModel[8];
        }


        public void GetWeeklyJsonData()
        {

            var url = "https://www.jma.go.jp/bosai/forecast/data/forecast/400000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);

            var obj_from_json = JArray.Parse(reader.ReadToEnd());
            //one_day_weather.Date = https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json

            _Weekly_Weather = new WeatherModel[8];

            for (int i = 0; i < 6; i++)
            {
                //_Weekly_Weather[i + 1].Datetime = (DateTime)obj_from_json[1]["timeSeries"][0]["timeDifines"][i];
                //_Weekly_Weather[i + 1].Rainy_percent = (string)obj_from_json[1]["timeSeries"][0]["areas"][0]["pops"][i];
                //_Weekly_Weather[i + 1].MinTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMin"][i];
                //_Weekly_Weather[i + 1].MaxTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMax"][i];
            };

            for (int i = 0; i < 2; i++)
            {
                _Weekly_Weather[i].Datetime = (DateTime)obj_from_json[0]["timeSeries"][0]["timeDefines"][i];

            };


            var rainy_perset = (string)obj_from_json[0]["timeSeries"][1]["areas"][0]["pops"][1];
            for(int i = 2; i < 4; i++)
            {
                rainy_perset = rainy_perset + "/" + (string)obj_from_json[0]["timeSeries"][1]["areas"][0]["pops"][i];
            }
            _Weekly_Weather[1].Rainy_percent = rainy_perset;

            _Weekly_Weather[1].MinTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["temps"][0];
            _Weekly_Weather[1].MaxTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["temps"][1];

            System.Diagnostics.Debug.WriteLine(_Weekly_Weather.ToString());

        }




        //public void Get_hukuoka_jsonData()
        //{
        //    String url = "https://www.jma.go.jp/bosai/forecast/data/forecast/400000.json";

        //    WebRequest request = WebRequest.Create(url);
        //    WebResponse response = request.GetResponse();
        //    Stream response_stream = response.GetResponseStream();

        //    StreamReader reader = new StreamReader(response_stream);
        //    JObject json = JObject.Parse(reader.ReadToEnd());

        //    System.Diagnostics.Debug.WriteLine(json.ToString());

        //}
    }

    internal class WeatherModel
    {

        //public string Location{ get; set; }

        public string Rainy_percent { get; set; } = "hoge";

        public Condition Condition { get; set; }

        public int MaxTemperature { get; set; } = 1;

        public int MinTemperature { get; set; } = 1;

        public DateTime Datetime { get; set; }

    }
}
