using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace TimerLib
{
    using TimerLib.timers;

    /// <summary>
    /// タイマー生成クラス
    /// </summary>
    public static class TimerFactory
    {
        #region Constants

        /// <summary>
        /// タイマー種別
        /// </summary>
        public enum Kind
        {
            /// <summary>
            /// 高分解能タイマー
            /// </summary>
            HighReso,

            /// <summary>
            /// System.Timers.Timerのラップタイマー
            /// </summary>
            Server,

            /// <summary>
            /// System.Threading.Timerのラップタイマー
            /// </summary>
            Threading,
        }

        #endregion

        #region Fields

        /// <summary>
        /// タイマー型テーブル
        /// </summary>
        private static IDictionary<Kind, Type> _timers = new Dictionary<Kind, Type>()
        {
            { Kind.HighReso,    typeof(HighResoTimer) },
            { Kind.Server,      typeof(ServerTimer) },
            { Kind.Threading,   typeof(ThreadingTimer) },
        };

        #endregion

        #region Public Methods

        /// <summary>
        /// タイマーの取得
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="id"></param>
        /// <param name="interval"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public static ICustomTimer GetTimer(Kind kind = Kind.HighReso,
                                            string id = "",
                                            int interval = 1000,
                                            ThreadPriority priority = ThreadPriority.Normal)
        {
            Type type = null;

            if (!_timers.TryGetValue(kind, out type)) 
            {
                type = typeof(HighResoTimer);
            }

            return Activator.CreateInstance(type, 
                                            BindingFlags.Instance | BindingFlags.NonPublic, 
                                            null, 
                                            new object[]{id, interval, priority}, 
                                            null) as ICustomTimer;
        }

        #endregion
    }
}
