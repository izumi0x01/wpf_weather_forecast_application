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

        private List<WeatherModel> _Weekly_Weather = new List<WeatherModel>();

        public List<WeatherModel> Weekly_Weather { get { return _Weekly_Weather; } }


        public Weather()
        {
            for(int i = 0; i < 7; i++)
            {
                _Weekly_Weather.Add(new WeatherModel());
            }
        }
        public void GetWeeklyWeatherJsonData()
        {

            var url = "https://www.jma.go.jp/bosai/forecast/data/forecast/400000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);

            var obj_from_json = JArray.Parse(reader.ReadToEnd());
            //one_day_weather.Date = https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json



            // 一週間の日時
            for(int i = 0; i<7; i++)
            {
                string s = "";
                try
                {
                    s = (string)obj_from_json[1]["timeSeries"][0]["timeDefines"][i];
                }
                catch(Exception ex)
                {
                    return;
                }
                _Weekly_Weather[i].Datetime = Convert.ToDateTime(s);
            }

            // 一週間の天気コード
            for(int i = 0; i < 7; i++)
            {
                string s;
                s = (string)(obj_from_json[1]["timeSeries"][0]["areas"][0]["weatherCodes"][i]);
                if (s == "") 
                    s = "-1";

                _Weekly_Weather[i].WeatherCode = int.Parse(s);
            }

            //System.Diagnostics.Debug.WriteLine(obj_from_json[1]["timeSeries"][1]["areas"][0].ToString());


            // 一週間の最低気温
            for (int i = 0; i < 7; i++)
            {
                string s;
                s = (string)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMin"][i];
                if (s == "") 
                    s = "-1";

                _Weekly_Weather[i].MinTemperature = int.Parse(s);
            }

            // 一週間の最高気温
            for (int i = 0; i < 7; i++)
            {
                string s;
                s = (string)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMax"][i];
                if (s == "")
                    s = "-1";

                _Weekly_Weather[i].MaxTemperature = int.Parse(s);
            }




            // 降水確率
            for (int i = 0; i < 7; i++)
            {
                string s;
                s = (string)(obj_from_json[1]["timeSeries"][0]["areas"][0]["pops"][i] ?? "");
                if (s == "")
                    s = "-1";

                _Weekly_Weather[i].Rainy_percent = int.Parse(s);
            }

            //for (int i = 0; i < 6; i++)
            //{
            //    //_Weekly_Weather[i].Datetime = (string)obj_from_json[1]["timeSeries"][0]["timeDifines"][0] ?? "";
            //    _Weekly_Weather[i + 1].Rainy_percent = (string)(obj_from_json[1]["timeSeries"][0]["areas"][0]["pops"][i] ?? "");
            //    _Weekly_Weather[i + 1].MinTemperature = int.Parse((string)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMin"][i]);
            //    _Weekly_Weather[i + 1].MaxTemperature = int.Parse((string)obj_from_json[1]["timeSeries"][1]["areas"][0]["tempsMax"][i]);
            //};

            //for (int i = 0; i < 2; i++)
            //{
            //    _Weekly_Weather[i].Datetime = (string)obj_from_json[0]["timeSeries"][0]["timeDefines"][i];

            //};


            //var rainy_perset = (string)obj_from_json[0]["timeSeries"][1]["areas"][0]["pops"][1];
            //for(int i = 2; i < 4; i++)
            //{
            //    rainy_perset = rainy_perset + "/" + (string)obj_from_json[0]["timeSeries"][1]["areas"][0]["pops"][i];
            //}
            //_Weekly_Weather[1].Rainy_percent = rainy_perset;

            //_Weekly_Weather[1].MinTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["temps"][0];
            //_Weekly_Weather[1].MaxTemperature = (int)obj_from_json[1]["timeSeries"][1]["areas"][0]["temps"][1];


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

        public int Rainy_percent { get; set; } = -1;

        public Condition Condition { get; set; } = Condition.sunny;

        public int WeatherCode { get; set; } = -1;

        const string cloud_URI = "cloud.png";
        const string sun_URI = "sun.png";
        const string rain_URI = "rain.png";
        const string snow_URI = "snow.png";

        private string _image_URI = sun_URI;

        public string Image_URI { 
            get
            {
                switch (WeatherCode.ToString().ToList().First())
                {
                    case '1':
                        _image_URI = sun_URI;
                        break;
                    case '2':
                        _image_URI = cloud_URI;
                        break;
                    case '3':
                        _image_URI = rain_URI;
                        break;
                    case '4':
                        _image_URI = snow_URI;
                        break;
                    default:
                        _image_URI = sun_URI;
                        break;

                }

                return _image_URI;
            }
        }

        public int MaxTemperature { get; set; } = -1;

        public int MinTemperature { get; set; } = -1;

        public DateTime Datetime { get; set; } = DateTime.Now;

    }
}
