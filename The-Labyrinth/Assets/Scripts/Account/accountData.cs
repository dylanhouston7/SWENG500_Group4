using UnityEngine;
using System;
using System.Collections.Generic;

namespace Account
{
    [Serializable]
    public class AccountData
    {
        private String a_gamerTag;
        public String gamerTag
        {
            set { a_gamerTag = value; }
            get { return a_gamerTag; }
        }

        private string a_password;
        public String password
        {
            set { a_password = value; }
            get { return a_password; }
        }

        private String a_firstName;
        public String firstName
        {
            set { a_firstName = value; }
            get { return a_firstName; }
        }

        private String a_lastName;
        public String lastName
        {
            set { a_lastName = value; }
            get { return a_lastName; }
        }

        private String a_email;
        public String email
        {
            set { a_email = value; }
            get { return a_email; }
        }

        private DateTime a_birthday;
        public DateTime birthday
        {
            set { a_birthday = value; }
            get { return a_birthday; }
        }

        private List<Achievement> a_achievements;
        public List<Achievement> achievements
        {
            set { a_achievements = value; }
            get { return a_achievements; }
        }

        private List<AccountCompletedMaze> a_completedMazes;
        public List<AccountCompletedMaze> completedMazes
        {
            set { a_completedMazes = value; }
            get { return a_completedMazes; }
        }

        public virtual bool IsNull() { return false; }

        [Serializable]
        public class NullUser : AccountData
        {
            public override bool IsNull() { return true; }
        }

        public static AccountData GetInstance()
        {
            AccountData user = new AccountData();
            return user;
        }
    }
}
