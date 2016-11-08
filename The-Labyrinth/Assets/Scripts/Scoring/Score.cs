using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Scoring
{
    /// <summary>
    /// Simple class to store Score information
    /// </summary>
    public class ScoreContainer
    {
        public int InitialScore { get; set; }

        public int TotalScore { get; set; }

        public string Difficulty { get; set; }

        public int HintCount { get; set; }

        public int HintPenalty { get; set; }
    }
}
