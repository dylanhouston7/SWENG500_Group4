using System.Collections.Generic;
using System;
using Account;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Account.Tests
{
    /// <summary>This class contains parameterized unit tests for AccountData</summary>
    [TestClass]
    [PexClass(typeof(AccountData))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AccountDataTest
    {

        /// <summary>Test stub for GetInstance()</summary>
        [PexMethod]
        public AccountData GetInstanceTest()
        {
            AccountData result = AccountData.GetInstance();
            return result;
            // TODO: add assertions to method AccountDataTest.GetInstanceTest()
        }

        /// <summary>Test stub for IsNull()</summary>
        [PexMethod]
        public bool IsNullTest([PexAssumeUnderTest]AccountData target)
        {
            bool result = target.IsNull();
            return result;
            // TODO: add assertions to method AccountDataTest.IsNullTest(AccountData)
        }

        /// <summary>Test stub for get_achievements()</summary>
        [PexMethod]
        public List<Achievement> achievementsGetTest([PexAssumeUnderTest]AccountData target)
        {
            List<Achievement> result = target.achievements;
            return result;
            // TODO: add assertions to method AccountDataTest.achievementsGetTest(AccountData)
        }

        /// <summary>Test stub for get_birthday()</summary>
        [PexMethod]
        public DateTime birthdayGetTest([PexAssumeUnderTest]AccountData target)
        {
            DateTime result = target.birthday;
            return result;
            // TODO: add assertions to method AccountDataTest.birthdayGetTest(AccountData)
        }

        /// <summary>Test stub for get_completedMazes()</summary>
        [PexMethod]
        public List<AccountCompletedMaze> completedMazesGetTest([PexAssumeUnderTest]AccountData target)
        {
            List<AccountCompletedMaze> result = target.completedMazes;
            return result;
            // TODO: add assertions to method AccountDataTest.completedMazesGetTest(AccountData)
        }

        /// <summary>Test stub for get_email()</summary>
        [PexMethod]
        public string emailGetTest([PexAssumeUnderTest]AccountData target)
        {
            string result = target.email;
            return result;
            // TODO: add assertions to method AccountDataTest.emailGetTest(AccountData)
        }

        /// <summary>Test stub for get_firstName()</summary>
        [PexMethod]
        public string firstNameGetTest([PexAssumeUnderTest]AccountData target)
        {
            string result = target.firstName;
            return result;
            // TODO: add assertions to method AccountDataTest.firstNameGetTest(AccountData)
        }

        /// <summary>Test stub for get_gamerTag()</summary>
        [PexMethod]
        public string gamerTagGetTest([PexAssumeUnderTest]AccountData target)
        {
            string result = target.gamerTag;
            return result;
            // TODO: add assertions to method AccountDataTest.gamerTagGetTest(AccountData)
        }

        /// <summary>Test stub for get_lastName()</summary>
        [PexMethod]
        public string lastNameGetTest([PexAssumeUnderTest]AccountData target)
        {
            string result = target.lastName;
            return result;
            // TODO: add assertions to method AccountDataTest.lastNameGetTest(AccountData)
        }

        /// <summary>Test stub for get_password()</summary>
        [PexMethod]
        public string passwordGetTest([PexAssumeUnderTest]AccountData target)
        {
            string result = target.password;
            return result;
            // TODO: add assertions to method AccountDataTest.passwordGetTest(AccountData)
        }

        /// <summary>Test stub for set_achievements(List`1&lt;Achievement&gt;)</summary>
        [PexMethod]
        public void achievementsSetTest([PexAssumeUnderTest]AccountData target, List<Achievement> value)
        {
            target.achievements = value;
            // TODO: add assertions to method AccountDataTest.achievementsSetTest(AccountData, List`1<Achievement>)
        }

        /// <summary>Test stub for set_birthday(DateTime)</summary>
        [PexMethod]
        public void birthdaySetTest([PexAssumeUnderTest]AccountData target, DateTime value)
        {
            target.birthday = value;
            // TODO: add assertions to method AccountDataTest.birthdaySetTest(AccountData, DateTime)
        }

        /// <summary>Test stub for set_completedMazes(List`1&lt;AccountCompletedMaze&gt;)</summary>
        [PexMethod]
        public void completedMazesSetTest([PexAssumeUnderTest]AccountData target, List<AccountCompletedMaze> value)
        {
            target.completedMazes = value;
            // TODO: add assertions to method AccountDataTest.completedMazesSetTest(AccountData, List`1<AccountCompletedMaze>)
        }

        /// <summary>Test stub for set_email(String)</summary>
        [PexMethod]
        public void emailSetTest([PexAssumeUnderTest]AccountData target, string value)
        {
            target.email = value;
            // TODO: add assertions to method AccountDataTest.emailSetTest(AccountData, String)
        }

        /// <summary>Test stub for set_firstName(String)</summary>
        [PexMethod]
        public void firstNameSetTest([PexAssumeUnderTest]AccountData target, string value)
        {
            target.firstName = value;
            // TODO: add assertions to method AccountDataTest.firstNameSetTest(AccountData, String)
        }

        /// <summary>Test stub for set_gamerTag(String)</summary>
        [PexMethod]
        public void gamerTagSetTest([PexAssumeUnderTest]AccountData target, string value)
        {
            target.gamerTag = value;
            // TODO: add assertions to method AccountDataTest.gamerTagSetTest(AccountData, String)
        }

        /// <summary>Test stub for set_lastName(String)</summary>
        [PexMethod]
        public void lastNameSetTest([PexAssumeUnderTest]AccountData target, string value)
        {
            target.lastName = value;
            // TODO: add assertions to method AccountDataTest.lastNameSetTest(AccountData, String)
        }

        /// <summary>Test stub for set_password(String)</summary>
        [PexMethod]
        public void passwordSetTest([PexAssumeUnderTest]AccountData target, string value)
        {
            target.password = value;
            // TODO: add assertions to method AccountDataTest.passwordSetTest(AccountData, String)
        }
    }
}
