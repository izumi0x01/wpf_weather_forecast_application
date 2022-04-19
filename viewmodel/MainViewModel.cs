using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_weather_forecast_application.model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Reactive.Bindings;
using Microsoft.Xaml.Behaviors;
using Reactive.Bindings.Interactivity;
using System.Reactive.Linq;
using System.ComponentModel;


//ViewModelとはViewをモデル化したものである

namespace wpf_weather_forecast_application.viewmodel
{
    internal class MainViewModel
    {

        //void cmbItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    //...do your item selection code here...
        //}

        private Weather _Weather;

        //上記のサンプルプログラムのように、 Collection の末尾に要素を追加 する場合は ReactiveCollection<T> が適しています。
        //追加する要素を Select() を利用して記述できるので、 ObservableCollection<T> に比べてシンプルに書けます。
        //一方で、要素を Collection の途中に追加したり、並び替えや要素の編集には ReactiveCollection<T> は不向きです。
        //ObservableCollection<T> は Subscribe() の引数に指定する Action 内に処理を記述するので、
        //Collection の要素の入れ替えや編集など を記述する場合に適しています。 Collection の要素に対して処理を加えたい場合は
        //ObservableCollection<T> を利用するとよいでしょう。


        private ObservableCollection<WeatherModel> _Weekly_Weather { get; set; } = new ObservableCollection<WeatherModel>();
        /// <summary>
        /// 一週間の天気,読み取り専用
        /// </summary>
        public ObservableCollection<WeatherModel> Weekly_Weather { get { return _Weekly_Weather; } }



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
                    System.Diagnostics.Debug.WriteLine("except function _Weekly_Weather.Count:" + _Weekly_Weather.Count);
                    GetData();
                }));
            }

        }

        private void GetData()
        {
            this._Weather.testfunc();
            //this._Weekly_Weather = this._Weather.Weekly_Weather;

            //System.Diagnostics.Debug.WriteLine("this is VM:" + _Weekly_Weather.Count);
            //this._Weekly_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });
            //this._Weekly_Weather.Add(new WeatherModel() { Temperature = 24.5, Condition = Condition.cloud, Date = "2/21", MaxTemperature = 26, MinTemperature = 20, Rainy_percent = 20, area = "huga" });
            this._Weather.GetJsonData();

        }

        public void Execute()
        {
            // とりあえず呼ばれたことがわかるようにVMでメッセージボックス出してます。
            // 本当は、VMでこんなことしたらダメよ！

            System.Windows.MessageBox.Show("hoge");
                return;

        }

        //Actionは引数を持たないといけない．引数あり，返り値なし．
        //Funcは，引数なし，返り値あり．

    }
}
