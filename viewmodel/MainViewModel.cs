using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_weather_forecast_application.model;

namespace wpf_weather_forecast_application.viewmodel
{
    internal class MainViewModel
    {

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
