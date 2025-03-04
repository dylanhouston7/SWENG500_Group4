using System;
using Account;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Account.Tests
{
    /// <summary>This class contains parameterized unit tests for Achievement</summary>
    [TestClass]
    [PexClass(typeof(Achievement))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AchievementTest
    {

        /// <summary>Test stub for get_dateAchieved()</summary>
        [PexMethod]
        public DateTime dateAchievedGetTest([PexAssumeUnderTest]Achievement target)
        {
            DateTime result = target.dateAchieved;
            return result;
            // TODO: add assertions to method AchievementTest.dateAchievedGetTest(Achievement)
        }

        /// <summary>Test stub for get_description()</summary>
        [PexMethod]
        public string descriptionGetTest([PexAssumeUnderTest]Achievement target)
        {
            string result = target.description;
            return result;
            // TODO: add assertions to method AchievementTest.descriptionGetTest(Achievement)
        }

        /// <summary>Test stub for get_id()</summary>
        [PexMethod]
        public int idGetTest([PexAssumeUnderTest]Achievement target)
        {
            int result = target.id;
            return result;
            // TODO: add assertions to method AchievementTest.idGetTest(Achievement)
        }

        /// <summary>Test stub for get_points()</summary>
        [PexMethod]
        public int pointsGetTest([PexAssumeUnderTest]Achievement target)
        {
            int result = target.points;
            return result;
            // TODO: add assertions to method AchievementTest.pointsGetTest(Achievement)
        }

        /// <summary>Test stub for get_title()</summary>
        [PexMethod]
        public string titleGetTest([PexAssumeUnderTest]Achievement target)
        {
            string result = target.title;
            return result;
            // TODO: add assertions to method AchievementTest.titleGetTest(Achievement)
        }

        /// <summary>Test stub for set_dateAchieved(DateTime)</summary>
        [PexMethod]
        public void dateAchievedSetTest([PexAssumeUnderTest]Achievement target, DateTime value)
        {
            target.dateAchieved = value;
            // TODO: add assertions to method AchievementTest.dateAchievedSetTest(Achievement, DateTime)
        }

        /// <summary>Test stub for set_description(String)</summary>
        [PexMethod]
        public void descriptionSetTest([PexAssumeUnderTest]Achievement target, string value)
        {
            target.description = value;
            // TODO: add assertions to method AchievementTest.descriptionSetTest(Achievement, String)
        }

        /// <summary>Test stub for set_id(Int32)</summary>
        [PexMethod]
        public void idSetTest([PexAssumeUnderTest]Achievement target, int value)
        {
            target.id = value;
            // TODO: add assertions to method AchievementTest.idSetTest(Achievement, Int32)
        }

        /// <summary>Test stub for set_points(Int32)</summary>
        [PexMethod]
        public void pointsSetTest([PexAssumeUnderTest]Achievement target, int value)
        {
            target.points = value;
            // TODO: add assertions to method AchievementTest.pointsSetTest(Achievement, Int32)
        }

        /// <summary>Test stub for set_title(String)</summary>
        [PexMethod]
        public void titleSetTest([PexAssumeUnderTest]Achievement target, string value)
        {
            target.title = value;
            // TODO: add assertions to method AchievementTest.titleSetTest(Achievement, String)
        }
    }
}
