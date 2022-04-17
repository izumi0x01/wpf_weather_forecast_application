using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_weather_forecast_application.view;
using wpf_weather_forecast_application.viewmodel;

namespace wpf_weather_forecast_application
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //データバインディングってなんだよ
            //値を一度だけフィールドに代入するのではなくて，Viewの一か所で値が変化するたびに他の箇所でも値が変化する．
            base.OnStartup(e);
            var w = new MainView();
            var vm = new MainViewModel();

            //データコンテクストは，プロパティ名．
            //デフォルトでは，ViewからViewModelのデータコンテクストプロパティに値がセットされたとき，データコンテキストに通知される．データコンテクストは双方向プロパティ？
            //ViewModelのデータコンテクストプロパティへ，動的に値が代入されても，Viewには通知されない．そのため，リアクティブプロパティを使用している．
            //ViewModelのインスタンスに含まれる，フィールドの値が変更されたかどうかの通知が，データバインディング．
            //DataContextにｖｍを紐づけた時点で，既に相互参照になっている．
            
            w.DataContext = vm;
            
            w.Show();

            //var t = Task.Delay(10000);
            //t.ContinueWith((task) => { vm._Text.Value = "待機終了"; });
            //vm._Text.Value = "メソッド呼び出し終了";
        }
    }
}
