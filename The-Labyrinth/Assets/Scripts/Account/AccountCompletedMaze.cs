using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account
{
    [Serializable]
    public class AccountCompletedMaze
    {
        private Guid a_maze_guid;
        public Guid maze_guid
        {
            set { a_maze_guid = value; }
            get { return a_maze_guid; }
        }

        private DateTime a_dateAcheived;
        public DateTime dateAchieved
        {
            set { a_dateAcheived = value; }
            get { return a_dateAcheived; }
        }

        private int a_points;
        public int points
        {
            set { a_points = value; }
            get { return a_points; }
        }
    }
}
