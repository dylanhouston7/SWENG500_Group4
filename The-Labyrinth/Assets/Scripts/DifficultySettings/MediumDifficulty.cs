using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;
using MazeStructure;

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

        public string DifficultyString
        {
            get
            {
                return "MEDIUM";
            }
        }

        public Maze2D GetRandomMaze()
        {
            return MazeStructure.Maze2D.GetInstance(10, 10);
        }
    }
}
