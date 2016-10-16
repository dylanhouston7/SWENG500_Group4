using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;
using MazeStructure;

namespace Assets.Scripts.DifficultySettings
{
    public class HardDifficulty : IDifficulty
    {
        public string Description
        {
            get
            {
                return "This difficulty does have timing restrictions, and the mazes are bigger than medium mode.";
            }
        }

        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.HARD;
            }
        }

        public ITimer timer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DifficultyString
        {
            get
            {
                return "HARD";
            }
        }

        public Maze2D GetRandomMaze()
        {
            return MazeStructure.Maze2D.GetInstance(15, 15);
        }
    }
}
