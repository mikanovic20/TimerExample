using System;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace TimerLib.timers
{
    using SvTimer = System.Timers.Timer;
    
    /// <summary>
    /// System.Timers.Timerのラップタイマー
    /// </summary>
    internal class ServerTimer : ICustomTimer
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
        private SvTimer _timer;

        /// <summary>
        /// 内部Stopwatchオブジェクト
        /// </summary>
        private Stopwatch _stopwatch;

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
                if (_timer != null && _timer.Enabled)
                {
                    _timer.Interval = _interval;
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
        public ThreadPriority Priority { get; set; }

        #endregion

        #region Constructors

        static ServerTimer()
        {
            int minWorkerThread, minCompletionPortThread;

            ThreadPool.GetMinThreads(out minWorkerThread, out minCompletionPortThread);
            ThreadPool.SetMinThreads(DEFAULT_THREAD_NUM, minCompletionPortThread);
        }

        internal ServerTimer(string id = "",
                           int interval = 1000,
                            ThreadPriority priority = ThreadPriority.Normal)
        {
            Id = id;
            _interval = interval;
            Priority = priority;

            _timer = new SvTimer(Interval);
            _timer.AutoReset = true;
            _timer.Elapsed += ElapsedCallback;

            _stopwatch = new Stopwatch();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// タイマー開始
        /// </summary>
        public void Start()
        {
            if (_timer == null) return;

            _stopwatch.Reset();
            _stopwatch.Start();

            _timer.Start();
        }

        /// <summary>
        /// タイマー停止
        /// </summary>
        public void Stop()
        {
            if (_timer == null) return;

            _stopwatch.Stop();

            _timer.Stop();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Elapsedイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ElapsedCallback(object sender, ElapsedEventArgs e)
        {
            _stopwatch.Stop();

            // イベント発行
            Tick(this, _stopwatch.Elapsed);

            _stopwatch.Reset();
            _stopwatch.Start();
        }

        #endregion
    }
}
