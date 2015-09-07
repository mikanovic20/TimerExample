using System;
using System.Threading;

namespace TimerLib
{
    /// <summary>
    /// カスタムタイマーインタフェース
    /// </summary>
    public interface ICustomTimer
    {
        #region Events

        /// <summary>
        /// Tickイベント
        /// </summary>
        event Action<object, TimeSpan> Tick;

        #endregion

        #region Properties

        /// <summary>
        /// タイマーID
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// タイマーインターバル
        /// </summary>
        int Interval { get; set; }

        /// <summary>
        /// PCが高分解能タイマーを使用しているか
        /// </summary>
        bool UseHighReso { get; }

        /// <summary>
        /// タイマーのタスク優先度
        /// </summary>
        ThreadPriority Priority { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// タイマー開始
        /// </summary>
        void Start();

        /// <summary>
        /// タイマー停止
        /// </summary>
        void Stop();

        #endregion
    }
}
