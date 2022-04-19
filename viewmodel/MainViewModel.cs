using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_weather_forecast_application.model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reactive.Bindings;
using Microsoft.Xaml.Behaviors;
using Reactive.Bindings.Interactivity;
using System.Reactive.Linq;
using System.ComponentModel;

namespace wpf_weather_forecast_application.viewmodel
{
    internal class MainViewModel
    {

        //void cmbItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    //...do your item selection code here...
        //}

        private Weather _Weather;

        public ObservableCollection<WeatherModel> One_day_Weather { get; } = new ObservableCollection<WeatherModel>();

        public List<WeatherModel> One_Week_Weather;

        //プロパティを持たないと，VMに反映されない．なぜだぁ

        public MainViewModel()
        {
            this._Weather = new Weather();
        }
        
        private DelegateCommand _GetDataCommand;

        public DelegateCommand GetDataCommand
        {
            get
            {
                return this._GetDataCommand ?? (this._GetDataCommand = new DelegateCommand(_ =>
                {
                    GetData();
                }));
            }

        }

        private void GetData()
        {
            //this._Weather.GetJsonData();
            //this.One_day_Weather = this._Weather.One_week_weather.ToList();
            //this.One_day_Weather = new List<WeatherModel>(){
            //    new WeatherModel() { Temperature=24.5, Condition=Condition.cloud, Date="2/21", MaxTemperature = 26, MinTemperature = 20,Rainy_percent=20,area = "huga" } 
            //};
            One_day_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });

        }

        public void Execute()
        {
            // とりあえず呼ばれたことがわかるようにVMでメッセージボックス出してます。
            // 本当は、VMでこんなことしたらダメよ！

            System.Windows.MessageBox.Show("hoge");
                return;

        }



        // デリゲートは，使い道がよくわからないからすぐ忘れる．
        // マルチキャスト機能：一つのデリゲート変数に，複数のデリゲートを登録することができる．→つまり，caluculatorデリゲートは，mulやsubやdivなどの関数を処理に保存できる．
        //C#の_  は， discardを意味する

        //Actionは引数を持たないといけない．引数あり，返り値なし．
        //Funcは，引数なし，返り値あり．

    }
}
