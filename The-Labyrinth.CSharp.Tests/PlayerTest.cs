using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;

namespace PlayerTest.Tests
{
    /// <summary>This class contains parameterized unit tests for Player</summary>
    [PexClass(typeof(global::Player))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PlayerTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public global::Player ConstructorTest()
        {
            global::Player target = new global::Player();
            return target;
            // TODO: add assertions to method PlayerTest.ConstructorTest()
        }

        /// <summary>Test stub for setPlayerPosition(Vector3)</summary>
        [PexMethod]
        public void setPlayerPositionTest([PexAssumeUnderTest]global::Player target, Vector3 position)
        {
            target.setPlayerPosition(position);
            // TODO: add assertions to method PlayerTest.setPlayerPositionTest(Player, Vector3)
        }
    }
}
