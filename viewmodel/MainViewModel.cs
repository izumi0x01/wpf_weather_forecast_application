using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_weather_forecast_application.model;
using Reactive.Bindings;

namespace wpf_weather_forecast_application.viewmodel
{
    internal class MainViewModel
    {
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

        public List<Data> _Data { get; set; }
        public MainViewModel()
        {
            this._Data = new List<Data>
            {
                new Data{Temperature=24.5, Weather=Weather.cloud, Date="2/21", MaxTemperature = 26, MinTemperature = 20,Rainy_percent=20},
                new Data{Temperature=25.5, Weather=Weather.cloud, Date="2/22", MaxTemperature = 28, MinTemperature = 24,Rainy_percent=10},
                new Data{Temperature=26.5, Weather=Weather.rain, Date="2/23", MaxTemperature = 29, MinTemperature = 21,Rainy_percent=30},
                new Data{Temperature=24.5, Weather=Weather.cloud, Date="2/21", MaxTemperature = 26, MinTemperature = 20,Rainy_percent=20},
                new Data{Temperature=25.5, Weather=Weather.cloud, Date="2/22", MaxTemperature = 28, MinTemperature = 24,Rainy_percent=10},
                new Data{Temperature=25.5, Weather=Weather.cloud, Date="2/22", MaxTemperature = 28, MinTemperature = 24,Rainy_percent=10},
                new Data{Temperature=25.5, Weather=Weather.cloud, Date="2/22", MaxTemperature = 28, MinTemperature = 24,Rainy_percent=10},
            };
        }


        private GetJson _getJson;

        private DelegateCommand _clearCommand;

        private DelegateCommand _testCommand;

        //public DelegateCommand TestCommand
        //{
        //    get
        //    {
        //        return this._testCommand ?? (this._testCommand = new DelegateCommand(_ => { OnTest(); }))
        //    }
        //    return this._testCommand;
        //}

        //private void OnTest()
        //{
        //    this._data.testdata = s;
        //}
        //private Data _data;

        // デリゲートは，使い道がよくわからないからすぐ忘れる．
        // マルチキャスト機能：一つのデリゲート変数に，複数のデリゲートを登録することができる．→つまり，caluculatorデリゲートは，mulやsubやdivなどの関数を処理に保存できる．
        //C#の_  は， discardを意味する

        //Actionは引数を持たないといけない．引数あり，返り値なし．
        //Funcは，引数なし，返り値あり．
        public DelegateCommand ClearCommand
        {
            get
            {
                if(this._clearCommand == null)
                {
                     //変数名に破棄を指定したものが，_である．変数のメモリを確保した後に，自動的に破棄される．
                    this._clearCommand = new DelegateCommand(( _) => { _Text.Value = "";  });
                }
                return this._clearCommand;
            }

        }


//        65 行目で新たに SetProperty() メソッドを追加し、プロパティ値変更にはこのメソッドを使用するようにしています。
//SetProperty() メソッドでは、値が異なっているか、異なっている場合値を更新し、RaiseProeprtyChanged() メソッド
//を呼び出す、という一連の処理をおこなっています。プロパティは様々な型が想定されるため、汎用的にするためにジェネ
//リックメソッドを適用しています。ジェネリックメソッドとは、型が異なるだけで処理内容が同一なものを扱うときに重宝
//する C# 言語仕様の一つです。
//このヘルパを使うと、18 行目のように単にプロパティ値を設定するだけのプロパティはたった 1 行で書けるようになり
//ます。また、変更があった場合に true を戻り値として返しているため、30 行目のように if 文のステートメントとして
//も使うことができます。さらに、RaisePropertyChanged() メソッドと同じく CallerMemberName 属性を使用しているた
//め、プロパティ名を明示的に書かなくてもプロパティ値更新を正常におこなえます。

        //public MainViewModel()
        //{
        //    this.locate = new Data();
        //}

        //public List<Data> locate
        //{

        //}
    }
}
