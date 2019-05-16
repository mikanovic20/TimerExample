using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TimerLib.timers
{
    /// <summary>
    /// 高分解能タイマー
    /// </summary>
    /// <remarks>
    /// .NETのStopwatchを使用したタイマー
    /// </remarks>
    internal class HighResoTimer : ICustomTimer
    {
        #region Events

        /// <summary>
        /// Tickイベント
        /// </summary>
        public event Action<object, TimeSpan> Tick = (sender, elapsed) => { };

        #endregion

        #region Constants

        /// <summary>
        /// スレッドプールに生成しておくスレッド数
        /// </summary>
        /// <remarks>
        /// ※これにより複数タイマー生成、
        /// 　起動時のタスク生成が軽くなる
        /// </remarks>
        private static readonly int DEFAULT_THREAD_NUM = 8;

        /// <summary>
        /// インターバルチェック用ループ内スリープ(msec)
        /// </summary>
        /// <remarks>
        /// ※0が理想だが、GUIがフリーズする
        /// </remarks>
        private static readonly int TIME_CHECK_INTERVAL = 1;

        /// <summary>
        /// 誤差調整用
        /// </summary>
        private static readonly double MSEC_FOR_DELAY = 0.8;

        #endregion

        #region Fields

        /// <summary>
        /// 内部Stopwatchオブジェクト
        /// </summary>
        private Stopwatch _stopwatch;

        /// <summary>
        /// タスクキャンセル用トークンソース
        /// </summary>
        private CancellationTokenSource SyncTokenSource {
            get { lock ( _lockOfTokenSource ) { return _tokenSource; } }
            set { lock ( _lockOfTokenSource ) { _tokenSource = value; } }
        }
        private CancellationTokenSource _tokenSource;
        private readonly object _lockOfTokenSource = new object();

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
            get 
            {
                lock (_syncInterval)
                {
                    return _interval;
                }
            }
            set
            {
                lock (_syncInterval)
                {
                    _interval = value;
                }
            } 
        }
        private int _interval;
        private object _syncInterval = new object();

        /// <summary>
        /// PCが高分解能タイマーを使用しているか
        /// </summary>
        public bool UseHighReso { get { return Stopwatch.IsHighResolution; } }

        /// <summary>
        /// タイマーのタスク優先度
        /// </summary>
        public ThreadPriority Priority { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// staticコンストラクタ
        /// </summary>
        static HighResoTimer()
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
        internal HighResoTimer(string id = "", 
                                      int interval = 1000, 
                                      ThreadPriority priority = ThreadPriority.Normal)
        {
            Id = id;
            _interval = interval;
            Priority = priority;

            _stopwatch = new Stopwatch();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// タイマー開始
        /// </summary>
        public void Start()
        {
            var token = default( CancellationToken );

            lock ( _lockOfTokenSource ) {
                if ( _tokenSource == null || _tokenSource.IsCancellationRequested ) {
                    _tokenSource?.Dispose();
                    _tokenSource = new CancellationTokenSource();
                }
                token = _tokenSource.Token;
            }

            // タスク生成(スレッドプールから取得)
            Task.Factory.StartNew(() =>
            {
                // タイマータスクの優先度を設定
                Thread.CurrentThread.Priority = Priority;

                // タイマー計測
                while (true)
                {
                    // ストップウォッチのリセットと開始
                    _stopwatch.Reset();
                    _stopwatch.Start();

                    // キャンセル要求チェック
                    if ( SyncTokenSource?.IsCancellationRequested ?? true ) {
                        return;
                    }

                    // 経過時間のチェック
                    while (_stopwatch.Elapsed < TimeSpan.FromMilliseconds(Interval - MSEC_FOR_DELAY))
                    {
                        // ※ここの処理をどうするか
                        Thread.Sleep(TIME_CHECK_INTERVAL);

                        // キャンセル要求チェック
                        if ( SyncTokenSource?.IsCancellationRequested ?? true ) {
                            return;
                        }
                    }

                    // ストップウォッチ停止
                    _stopwatch.Stop();

                    // キャンセル要求チェック
                    if ( SyncTokenSource?.IsCancellationRequested ?? true ) {
                        return;
                    }

                    // Tickイベント発行
                    Tick(this, _stopwatch.Elapsed);

                    // キャンセル要求チェック
                    if ( SyncTokenSource?.IsCancellationRequested ?? true ) {
                        return;
                    }
                }

            }, token).ContinueWith(task =>
            {
                //
                // タスク完了後継続処理
                // (キャンセル時)
                //
                if ( task.IsCanceled ) {

                    lock ( _lockOfTokenSource ) {

                        if ( _tokenSource != null &&
                             _tokenSource.IsCancellationRequested ) {
                            // トークンソースの解放
                            _tokenSource.Dispose();
                            _tokenSource = null;
                        }

                        if ( _stopwatch != null && _stopwatch.IsRunning ) {
                            // 念のためストップウォッチ停止
                            _stopwatch.Stop();
                        }
                    }
                }
            } );
        }

        /// <summary>
        /// タイマー停止
        /// </summary>
        public void Stop()
        {
            lock ( _lockOfTokenSource ) {
                // タスクキャンセル要求
                if ( SyncTokenSource != null ) {
                    SyncTokenSource.Cancel();
                }
            }
        }

        #endregion
    }
}
