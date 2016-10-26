// File: CountUpTimer.cs
// Description: Specifies a "count up" timer
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Timer
{
    /// <summary>
    /// A "count up" timer
    /// </summary>
    public class CountUpTimer : ITimer
    {
        private float _time = 0;

        public void Update(float time)
        {
            _time += time;

        }

        public int GetTimeInSeconds()
        {
            return System.Convert.ToInt32(_time);
        }

        public int GetTotalSecondsRecorded()
        {
            return System.Convert.ToInt32(_time);
        }

        
    }
}
