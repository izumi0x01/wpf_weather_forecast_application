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
        //{
        //    get
        //    {
        //        return one_day_weather;
        //    }

        //}

        //reactivecollectionとは違う？どっちも機能としては一緒．
        private ObservableCollection<WeatherModel> _Weekly_Weather { get; set; } = new ObservableCollection<WeatherModel>();

        public ObservableCollection<WeatherModel> Weekly_Weather { get { return _Weekly_Weather; } }

        public void testfunc()
        {
            System.Diagnostics.Debug.WriteLine("called");

            this._Weekly_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });
            this._Weekly_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });
            this._Weekly_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });
            System.Diagnostics.Debug.WriteLine("this is M:" + _Weekly_Weather.Count);

        }

        public void GetJsonData()
        {

            var url = "https://www.jma.go.jp/bosai/forecast/data/forecast/400000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);

            var obj_from_json = JArray.Parse(reader.ReadToEnd());
            System.Diagnostics.Debug.WriteLine(obj_from_json);

            

            //this.tempdata = json.ToString();
            //Console.WriteLine(json.ToString());

            //one_day_weather.Date = https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json

            //var obj_from_json = JObject.Parse(reader.ReadToEnd());
            var forecast_datetime = obj_from_json[0]["timeSeries"][0]["areas"][0]["weathers"][0];

            System.Diagnostics.Debug.WriteLine(forecast_datetime);

            //var forecast_area = obj_from_json["weather"]["targetArea"];

            //this.one_day_weather.area = (string)forecast_area;
            //this.one_day_weather.datetime = (string)forecast_datetime;

        }

        public void Get_hukuoka_jsonData()
        {
            String url = "https://www.jma.go.jp/bosai/forecast/data/forecast/400000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);
            JObject json = JObject.Parse(reader.ReadToEnd());

            System.Diagnostics.Debug.WriteLine(json.ToString());

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
