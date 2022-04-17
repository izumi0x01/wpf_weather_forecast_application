using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace wpf_weather_forecast_application.viewmodel
{

    //ICommandは，3つのメソッドを用意しておかないといけない．
    //void Execute(object) (メソッド) コマンドが実行されたときの処理をおこないます。
    //bool CanExecute(object) (メソッド) コマンドが実行可能かどうかの判別処理をおこないます。
    //event EventHandler CanExecuteChanged (イベント) コマンドが実行可能かどうかの判別処理に関する状態が変更したことを UI に通知します。

    //refキーワードは，値のコピーを作成せずに，参照を渡す方法を参照渡しという．
    //つまり，値はコピーせず，参照だけを渡すから，メソッド内の変更は，呼び出し元メソッドの変数にも反映される．
     //ref:戻り値を書かない．引数は，実物を触っていない．関数として，操作をしない．cでいう，strcpなんかな． out:参照渡しを行う一つ．
    internal class DelegateCommand : ICommand//抽象クラスです．
    {
        /// <summary>
        /// コマンド実行時の処理内容を保持します。返り値なし，引数あり．入力引数に，object型，戻り値なし．
        /// </summary>
        private Action<object> _execute;
        /// <summary>
        /// コマンド実行可能判別の処理内容を保持します。引数あり，返り値あり．入力引数に，object型，戻り値にbool型を指定している．
        /// </summary>
        private Func<object, bool> _canExecute;
        /// <summary>
        /// 新しいインスタンスを生成します。コンストラクタとして，
        /// コンストラクタ初期化子thisは自分自身のクラス内にある，別のコンストラクタを呼び出せる．baseは継承元の親クラスのコンストラクタ．
        /// </summary>
        /// <param name="execute">コマンド実行処理を指定します。</param>
        public DelegateCommand(Action<object> execute)
        : this(execute, null)
        {
        }
        /// <summary>
        /// 新しいインスタンスを生成します。こっち使ってるじゃん．
        /// </summary>
        /// <param name="execute">コマンド実行処理を指定します。</param>
        /// <param name="canExecute">コマンド実行可能判別処理を指定します。もし，コマンドが実行可能なのか判別したいなら，こっちを使う．
        /// これもしかして，処理が一個しか追加できへんのか？</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        #region ICommand の実装

        /// <summary>
        /// コマンドが実行可能かどうかの判別処理をおこないます。
        /// </summary>
        /// <param name="parameter">判別処理に対するパラメータを指定します。</param>
        /// <returns>実行可能な場合に true を返します。</returns>
        public bool CanExecute(object parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }
        /// <summary>
        /// 実行可能かどうかの判別処理に関する状態が変更されたときに発生します。
        /// イベントハンドラとは，イベントが発生した時に行う処理の事．イベントハンドラってなんだ．
        /// イベント発生側：観測可能 observable で，イベント受取側：観測者 observer=handler
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// CanExecuteChanged イベントを発行します。
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }
        /// <summary>
        /// コマンドが実行されたときの処理をおこないます。
        /// 実際の処理？
        /// コマンドが実行されるときに Execute() メソッドが呼ばれます。DelegateCommand クラスでは、
        /// Execute() メソッドが呼ばれると、コンストラクタで指定された _execute が保持しているメソッドを実行するようにしています。
        /// つまり、DelegateCommand クラスを使う側の処理が委譲されています．今回は，コンストラクタの働きが強い．
        /// </summary>
        /// <param name="parameter">コマンドに対するパラメータを指定します。</param>
        public void Execute(object parameter)
        {
            if (this._execute != null)//_executeが，nullの時が，何もしない？_executeが
                this._execute(parameter);
        }
        #endregion ICommand の実装
    }
}
