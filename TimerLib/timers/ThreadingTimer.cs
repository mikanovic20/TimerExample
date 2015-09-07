using System;
using System.Threading;
using System.Diagnostics;

namespace TimerLib.timers
{
    using ThTimer = System.Threading.Timer;

    /// <summary>
    /// System.Threading.Timerのラップタイマー
    /// </summary>
    internal class ThreadingTimer : ICustomTimer
    {
        #region Constants

        /// <summary>
        /// スレッドプールに生成しておくスレッド数
        /// </summary>
        /// <remarks>
        /// ※これにより複数タイマー生成、
        /// 　起動時のタスク生成が軽くなる
        /// </remarks>
        private static readonly int DEFAULT_THREAD_NUM = 8;

        #endregion

        #region Events

        /// <summary>
        /// Tickイベント
        /// </summary>
        public event Action<object, TimeSpan> Tick = (sender, elapsed) => { };

        #endregion


        #region Fields

        /// <summary>
        /// 内部タイマーオブジェクト
        /// </summary>
        private ThTimer _timer;

        /// <summary>
        /// 内部Stopwatchオブジェクト
        /// </summary>
        private Stopwatch _stopwatch;

        /// <summary>
        /// タイマー動作中かどうか
        /// </summary>
        private bool _isRunning;

        #endregion

        #region Properties

        /// <summary>
        /// タイマーID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// タイマーインターバル
        /// </summary>
        public int Interval 
        {
            get { return _interval; } 
            set
            {
                _interval = value;
                if (_timer != null && _isRunning)
                {
                    _timer.Change(0, _interval);
                }
            } 
        }
        private int _interval;

        /// <summary>
        /// PCが高分解能タイマーを使用しているか
        /// </summary>
        public bool UseHighReso { get { return false; } }

        /// <summary>
        /// タイマーのタスク優先度
        /// </summary>
        /// <remarks>
        /// ※影響しない
        /// </remarks>
        public ThreadPriority Priority { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// staticコンストラクタ
        /// </summary>
        static ThreadingTimer()
        {
            int minWorkerThread, minCompletionPortThread;

            ThreadPool.GetMinThreads(out minWorkerThread, out minCompletionPortThread);
            ThreadPool.SetMinThreads(DEFAULT_THREAD_NUM, minCompletionPortThread);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="interval"></param>
        /// <param name="priority"></param>
        internal ThreadingTimer(string id = "",
                              int interval = 1000,
                              ThreadPriority priority = ThreadPriority.Normal)
        {
            Id = id;
            _interval = interval;
            Priority = priority;
            _isRunning = false;

            _timer = new ThTimer(new TimerCallback(Callback));

            _stopwatch = new Stopwatch();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// タイマー開始
        /// </summary>
        public void Start()
        {
            _stopwatch.Reset();
            _stopwatch.Start();

            _isRunning = true;
            _timer.Change(0, Interval);
        }

        /// <summary>
        /// タイマー停止
        /// </summary>
        public void Stop()
        {
            _stopwatch.Stop();
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            
            _isRunning = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// タイマーコールバックメソッド
        /// </summary>
        /// <param name="parameter"></param>
        private void Callback(object parameter)
        {
            _stopwatch.Stop();

            Tick(this, _stopwatch.Elapsed);

            _stopwatch.Reset();
            _stopwatch.Start();
        }

        #endregion
    }
}
