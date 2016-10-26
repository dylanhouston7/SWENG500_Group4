using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Scoring
{
    /// <summary>
    /// Simple class to store Score information
    /// </summary>
    public class Score
    {
        public int score { get; set; }

        public string difficulty { get; set; }

        public bool hintShown { get; set; }
    }
}
