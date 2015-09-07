using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace TimerUsers
{
    using TimerLib;

    /// <summary>
    /// テスト用フォーム
    /// </summary>
    /// <remarks>
    /// タイマーからのコールバックコンテキストで表示更新する
    /// </remarks>
    public partial class Form2 : Form
    {
        #region Constants

        private static readonly int DISPLAY_BOX_NUMBER = 8;
        private static readonly int DATA_RECV_INTERVAL_MSEC = 5;
        private static readonly TimerFactory.Kind TIMER_KIND = TimerFactory.Kind.HighReso;
        private static readonly int LINE_MAX_COUNT = 20;

        #endregion

        #region Fields - Flags etc...

        private bool isRunning = false;

        private object _syncObject = new object();

        #endregion

        #region Containers

        private List<RichTextBox> _rtbs = new List<RichTextBox>();
        private List<ICustomTimer> _dataReceiveTimers;

        #endregion

        #region Constructors

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form2()
        {
            InitializeComponent();

            this.Text = string.Format("{0} - {1} : Timers = {2}",
                this.Text, TIMER_KIND.ToString(), DISPLAY_BOX_NUMBER);

            // データ受信タイマー登録用リスト生成
            _dataReceiveTimers = new List<ICustomTimer>();
        }

        #endregion

        #region EventHandlers - Form

        private void Form1_Load(object sender, EventArgs e)
        {
            // 表示領域数分
            for (int i = 0; i < DISPLAY_BOX_NUMBER; i++)
            {
                // 表示領域をリストに登録
                _rtbs.Add(Controls.Find(string.Format("rtb{0}", i + 1), true)[0] as RichTextBox);

                // 対象のデータ受信タイマー生成
                var timer = TimerFactory.GetTimer(TIMER_KIND,
                                                  (i + 1).ToString(),
                                                  DATA_RECV_INTERVAL_MSEC,
                                                  ThreadPriority.Highest);

                // 対象のデータ受信タイマーのTickイベント登録
                timer.Tick += DataReceiveTimer_Tick;

                // データ受信タイマーをリストに登録
                _dataReceiveTimers.Add(timer);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 全データ受信タイマーのTickイベント解除
            _dataReceiveTimers.ForEach(timer => timer.Tick -= DataReceiveTimer_Tick);
        }

        #endregion

        #region EventHandlers - Components

        private void button1_Click(object sender, EventArgs e)
        {
            // データ受信タイマー停止中
            if (!isRunning)
            {
                // 表示領域をクリアしておく
                _rtbs.ForEach(rtb => rtb.Clear());

                // 全データ受信タイマー開始
                _dataReceiveTimers.ForEach(timer => timer.Start());
            }
            // データ受信タイマー稼動中
            else
            {
                // 全データ受信タイマー停止
                _dataReceiveTimers.ForEach(timer => timer.Stop());
            }

            // データ受信タイマー動作切替
            isRunning = !isRunning;

            // 表示切替
            button1.Text = isRunning ? "Stop" : "Start";
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            _dataReceiveTimers.ForEach(timer => timer.Interval = (int)nudInterval.Value);
        }

        #endregion

        #region Callbacks From Timers

        private void DataReceiveTimer_Tick(object sender, TimeSpan elapsed)
        {
            if (sender == null) return;

            var timer = sender as ICustomTimer;

            if (timer == null) return;

            // タイマーID
            // ※1～8
            var id = int.Parse(timer.Id);

            // コンテンツ文字列生成
            var contents = string.Format("timer-{1} : {0, 8:F4} ms\n", elapsed.TotalMilliseconds, id);

            // アクション生成
            Action action = () =>
            {
                // 行が満杯かどうかチェックし必要ならば削除
                CheckAndRemoveLineRichTextBox(_rtbs[id - 1]);

                // 表示
                _rtbs[id - 1].AppendText(contents);

                // 最新データにスクロールバー移動
                _rtbs[id - 1].ScrollToCaret();
            };

            try
            {
                // 表示更新
                if (InvokeRequired) Invoke(action); else action();
            }
            catch (ObjectDisposedException)
            {
                // 握りつぶす
            }
        }

        #endregion

        #region Private Methods

        private void CheckAndRemoveLineRichTextBox(RichTextBox richTextBox)
        {
            if (richTextBox.Lines.Length > LINE_MAX_COUNT)
            {
                int st_idx = richTextBox.GetFirstCharIndexFromLine(0);
                int nx_idx = richTextBox.GetFirstCharIndexFromLine(1);
                richTextBox.Text = richTextBox.Text.Remove(st_idx, nx_idx - st_idx);
            }
        }

        #endregion
    }
}
