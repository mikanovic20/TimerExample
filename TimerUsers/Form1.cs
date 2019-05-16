using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TimerUsers
{
	using TimerLib;

	/// <summary>
	/// テスト用フォーム
	/// </summary>
	/// <remarks>
	/// 表示更新用のタイマーで表示更新する
	/// </remarks>
	public partial class Form1 : Form
	{
		#region Constants

		private static readonly int DISPLAY_BOX_NUMBER = 8;
		private static readonly int DATA_RECV_INTERVAL_MSEC = 5;
		private static readonly int DISPLAY_UPDATE_INTERVAL_MSEC = 20;
		private static readonly TimerFactory.Kind TIMER_KIND = TimerFactory.Kind.HighReso;
		private static readonly int LINE_MAX_COUNT = 20;

		#endregion

		#region Fileds - Containers

		private List<RichTextBox> _rtbs = new List<RichTextBox>();
		private List<StringBuilder> _contentsBuffers;
		private List<ICustomTimer> _dataReceiveTimers;

		#endregion

		#region Fields - Flag etc...

		private bool isRunning = false;

		private object _syncObject = new object();

		#endregion

		#region Constructors

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1() {
			InitializeComponent();

			this.Text = string.Format( "{0} - {1} : Timers = {2}",
				this.Text, TIMER_KIND.ToString(), DISPLAY_BOX_NUMBER );

			// コンテンツ用バッファリスト生成
			_contentsBuffers = new List<StringBuilder>();

			// データ受信タイマー登録用リスト生成
			_dataReceiveTimers = new List<ICustomTimer>();
		}

		#endregion

		#region EventHandlers - Form

		private void Form1_Load( object sender, EventArgs e ) {
			// 表示領域数分
			for ( var i = 0; i < DISPLAY_BOX_NUMBER; i++ ) {
				// コンテンツ用バッファ作成
				_contentsBuffers.Add( new StringBuilder() );

				// 表示領域をリストに登録
				_rtbs.Add( Controls.Find( string.Format( "rtb{0}", i + 1 ), true )[ 0 ] as RichTextBox );

				// 対象のデータ受信タイマー生成
				var timer = TimerFactory.GetTimer( TIMER_KIND,
												  ( i + 1 ).ToString(),
												  DATA_RECV_INTERVAL_MSEC,
												  ThreadPriority.Highest );

				// 対象のデータ受信タイマーのTickイベント登録
				timer.Tick += DataReceiveTimer_Tick;

				// データ受信タイマーをリストに登録
				_dataReceiveTimers.Add( timer );
			}

			// 表示更新タイマーの設定と開始
			UpdateTimer.Interval = DISPLAY_UPDATE_INTERVAL_MSEC;
			UpdateTimer.Start();
		}

		private void Form1_FormClosed( object sender, FormClosedEventArgs e ) {
			// 全データ受信タイマーのTickイベント解除
			_dataReceiveTimers.ForEach( timer => timer.Tick -= DataReceiveTimer_Tick );

			// 表示更新タイマーの停止
			UpdateTimer.Stop();
		}

		#endregion

		#region EventHandlers - Components

		private void button1_Click( object sender, EventArgs e ) {
			// データ受信タイマー停止中
			if ( !isRunning ) {
				// 表示領域をクリアしておく
				_rtbs.ForEach( rtb => rtb.Clear() );

				// 全データ受信タイマー開始
				_dataReceiveTimers.ForEach( timer => timer.Start() );
			}
			// データ受信タイマー稼動中
			else {
				// 全データ受信タイマー停止
				_dataReceiveTimers.ForEach( timer => timer.Stop() );
			}

			// データ受信タイマー動作切替
			isRunning = !isRunning;

			// 表示切替
			button1.Text = isRunning ? "Stop" : "Start";
		}

		private void nudInterval_ValueChanged( object sender, EventArgs e ) {
			_dataReceiveTimers.ForEach( timer => timer.Interval = ( int )nudInterval.Value );
		}

		#endregion

		#region EventHandlers - Timer for Display

		private void UpdateTimer_Tick( object sender, EventArgs e ) {
			lock ( _syncObject ) {
				// 全コンテンツに対し
				for ( var i = 0; i < _contentsBuffers.Count; i++ ) {
					// コンテンツ空の場合は飛ばす
					if ( _contentsBuffers[ i ].Length <= 0 ) {
						continue;
					}

					// 行が満杯かどうかチェックし必要ならば削除
					CheckAndRemoveLineRichTextBox( _rtbs[ i ] );

					// 表示
					_rtbs[ i ].AppendText( _contentsBuffers[ i ].ToString() );

					// コンテンツを空にする
					_contentsBuffers[ i ].Clear();

					// 最新データにスクロールバー移動
					_rtbs[ i ].ScrollToCaret();
				}
			}
		}

		#endregion

		#region Callback From Timers

		private void DataReceiveTimer_Tick( object sender, TimeSpan elapsed ) {
			if ( sender == null ) {
				return;
			}

			var timer = sender as ICustomTimer;

			if ( timer == null ) {
				return;
			}

			// タイマーID
			// ※1～8
			var id = int.Parse( timer.Id );

			// コンテンツ文字列生成
			var contents = string.Format( "timer-{1} : {0, 8:F4} ms\n", elapsed.TotalMilliseconds, id );

			lock ( _syncObject ) {
				// コンテンツ用バッファの末尾に詰め込む
				_contentsBuffers[ id - 1 ].Append( contents );
			}
		}

		#endregion

		#region Private Methods

		private void CheckAndRemoveLineRichTextBox( RichTextBox richTextBox ) {
			if ( richTextBox.Lines.Length > LINE_MAX_COUNT ) {
				var st_idx = richTextBox.GetFirstCharIndexFromLine( 0 );
				var nx_idx = richTextBox.GetFirstCharIndexFromLine( 1 );
				richTextBox.Text = richTextBox.Text.Remove( st_idx, nx_idx - st_idx );
			}
		}

		#endregion
	}
}
