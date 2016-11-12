using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account
{
    [Serializable]
    public class Achievement
    {
        private int a_id;
        public int id
        {
            set { a_id = value; }
            get { return a_id; }
        }

        private string a_title;
        public string title
        {
            set { a_title = value; }
            get { return a_title; }
        }

        private string a_description;
        public string description
        {
            set { a_description = value; }
            get { return a_description; }
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
