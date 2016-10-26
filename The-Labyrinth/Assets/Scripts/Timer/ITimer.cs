// File: ITimer.cs
// Description: Specifies an interface to use for all timers
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Timer
{
    /// <summary>
    /// An interface to use for all timers
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Updates the timer with the current time stored and the delta time provided
        /// </summary>
        /// <param name="time">The delta time since the last Update call was made</param>
        void Update(float time);

        /// <summary>
        /// Get the currently store time as an integer (could be a count down or count up timer)
        /// </summary>
        /// <returns>An integer representing the time stored</returns>
        int GetTimeInSeconds();

        /// <summary>
        /// Gets the total number of seconds recorded
        /// </summary>
        /// <returns>The total number of seconds recorded</returns>
        int GetTotalSecondsRecorded();

    }
}
