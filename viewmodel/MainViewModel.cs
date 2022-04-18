using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_weather_forecast_application.model;
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
        public ReactiveProperty<string> _Text { get; set; } = new ReactiveProperty<string>();
        //private string _upperString;
        ///// <summary>
        ///// すべて大文字に変換した文字列を取得します。
        ///// </summary>
        //public string UpperString
        //{
        //    get { return this._upperString; }
        //    private set
        //    {
        //        if (this._upperString != value)
        //        {
        //            this._upperString = value;
        //        }
        //    }
        //}
        //private string _inputString;
        ///// <summary>
        ///// 入力文字列を取得または設定します。
        ///// </summary>
        //public string InputString
        //{
        //    get { return this._inputString; }
        //    set
        //    {
        //        if (this._inputString != value)
        //        {
        //            this._inputString = value;
        //            // 入力された文字列を大文字に変換します
        //            this.UpperString = this._inputString.ToUpper();
        //            // 出力ウィンドウに結果を表示します
        //            System.Diagnostics.Debug.WriteLine("UpperString=" + this.UpperString);
        //        }
        //    }
        //}

        private Weather _Weather;

        public List<WeatherModel> One_Week_Weather;
        public List<WeatherModel> One_day_Weather;
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
            this._Weather.GetJsonData();
            //this.One_day_Weather = this._Weather.One_week_weather.ToList();
            this.One_day_Weather = new List<WeatherModel>(){ new WeatherModel() { area = "huga" } };
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


//        65 行目で新たに SetProperty() メソッドを追加し、プロパティ値変更にはこのメソッドを使用するようにしています。
//SetProperty() メソッドでは、値が異なっているか、異なっている場合値を更新し、RaiseProeprtyChanged() メソッド
//を呼び出す、という一連の処理をおこなっています。プロパティは様々な型が想定されるため、汎用的にするためにジェネ
//リックメソッドを適用しています。ジェネリックメソッドとは、型が異なるだけで処理内容が同一なものを扱うときに重宝
//する C# 言語仕様の一つです。
//このヘルパを使うと、18 行目のように単にプロパティ値を設定するだけのプロパティはたった 1 行で書けるようになり
//ます。また、変更があった場合に true を戻り値として返しているため、30 行目のように if 文のステートメントとして
//も使うことができます。さらに、RaisePropertyChanged() メソッドと同じく CallerMemberName 属性を使用しているた
//め、プロパティ名を明示的に書かなくてもプロパティ値更新を正常におこなえます。

    }
}
