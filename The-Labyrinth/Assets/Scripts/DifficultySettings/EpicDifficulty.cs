using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;
using MazeStructure;

namespace Assets.Scripts.DifficultySettings
{
    public class EpicDifficulty : IDifficulty
    {
        public string Description
        {
            get
            {
                return "You won't win in this mode.";
            }
        }

        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.EPIC;
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
                return "EPIC";
            }
        }

        public Maze2D GetRandomMaze()
        {
            return Maze2D.GetInstance(20, 20);
        }
    }
}
