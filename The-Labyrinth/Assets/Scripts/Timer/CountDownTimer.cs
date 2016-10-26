// File: CountDownTimer.cs
// Description: Specifies a "count down" timer
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Timer
{
    /// <summary>
    /// A "count down" timer
    /// </summary>
    public class CountDownTimer : ITimer
    {
        private float _time;
        private float _totalTimeRecorded;

        public CountDownTimer(float initialTime)
        {
            _time = initialTime;
            _totalTimeRecorded = 0;
        }

        public void Update(float time)
        {
            _time -= time;
            _totalTimeRecorded += time;
        }

        public int GetTimeInSeconds()
        {
            return System.Convert.ToInt32(_time);
        }

        public int GetTotalSecondsRecorded()
        {
            return System.Convert.ToInt32(_totalTimeRecorded);
        }
    }
}
