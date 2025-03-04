using System;
using Account;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Account.Tests
{
    /// <summary>This class contains parameterized unit tests for AccountCompletedMaze</summary>
    [TestClass]
    [PexClass(typeof(AccountCompletedMaze))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AccountCompletedMazeTest
    {

        /// <summary>Test stub for get_dateAchieved()</summary>
        [PexMethod]
        public DateTime dateAchievedGetTest([PexAssumeUnderTest]AccountCompletedMaze target)
        {
            DateTime result = target.dateAchieved;
            return result;
            // TODO: add assertions to method AccountCompletedMazeTest.dateAchievedGetTest(AccountCompletedMaze)
        }

        /// <summary>Test stub for get_maze_guid()</summary>
        [PexMethod]
        public Guid maze_guidGetTest([PexAssumeUnderTest]AccountCompletedMaze target)
        {
            Guid result = target.maze_guid;
            return result;
            // TODO: add assertions to method AccountCompletedMazeTest.maze_guidGetTest(AccountCompletedMaze)
        }

        /// <summary>Test stub for get_points()</summary>
        [PexMethod]
        public int pointsGetTest([PexAssumeUnderTest]AccountCompletedMaze target)
        {
            int result = target.points;
            return result;
            // TODO: add assertions to method AccountCompletedMazeTest.pointsGetTest(AccountCompletedMaze)
        }

        /// <summary>Test stub for set_dateAchieved(DateTime)</summary>
        [PexMethod]
        public void dateAchievedSetTest([PexAssumeUnderTest]AccountCompletedMaze target, DateTime value)
        {
            target.dateAchieved = value;
            // TODO: add assertions to method AccountCompletedMazeTest.dateAchievedSetTest(AccountCompletedMaze, DateTime)
        }

        /// <summary>Test stub for set_maze_guid(Guid)</summary>
        [PexMethod]
        public void maze_guidSetTest([PexAssumeUnderTest]AccountCompletedMaze target, Guid value)
        {
            target.maze_guid = value;
            // TODO: add assertions to method AccountCompletedMazeTest.maze_guidSetTest(AccountCompletedMaze, Guid)
        }

        /// <summary>Test stub for set_points(Int32)</summary>
        [PexMethod]
        public void pointsSetTest([PexAssumeUnderTest]AccountCompletedMaze target, int value)
        {
            target.points = value;
            // TODO: add assertions to method AccountCompletedMazeTest.pointsSetTest(AccountCompletedMaze, Int32)
        }
    }
}
