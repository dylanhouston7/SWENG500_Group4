using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;

namespace Assets.Scripts.DifficultySettings
{
    public class MediumDifficulty : IDifficulty
    {
        public string Description
        {
            get
            {
                return "This difficulty does not have timing restrictions, but the mazes are bigger than easy mode.";
            }
        }

        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.MEDIUM;
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
