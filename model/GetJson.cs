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

namespace wpf_weather_forecast_application.model
{
    internal class GetJson
    {
        public string tempdata { get; set; }
        public void GetJsonData()
        {
            String url = "https://www.jma.go.jp/bosai/forecast/data/overview_forecast/130000.json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream response_stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(response_stream);
            JObject json = JObject.Parse(reader.ReadToEnd());

            this.tempdata = json.ToString();
            //Console.WriteLine(json.ToString());

        }
    }
}
