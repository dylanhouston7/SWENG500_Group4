using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;

namespace Assets.Scripts.DifficultySettings
{
    public class EasyDifficulty : IDifficulty
    {
        public string Description
        {
            get
            {
                return "This difficulty is the easiest, with no timing restrictions. The player does not get many points in this mode.";
            }
        }

        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.EASY;
            }
        }

        public ITimer timer
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
