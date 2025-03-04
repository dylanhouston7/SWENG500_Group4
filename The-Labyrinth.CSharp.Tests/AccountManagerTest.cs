using System;
using Account;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Account.Tests
{
    /// <summary>This class contains parameterized unit tests for AccountManager</summary>
    [TestClass]
    [PexClass(typeof(AccountManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AccountManagerTest
    {

        /// <summary>Test stub for Awake()</summary>
        [PexMethod]
        public void AwakeTest([PexAssumeUnderTest]AccountManager target)
        {
            target.Awake();
            // TODO: add assertions to method AccountManagerTest.AwakeTest(AccountManager)
        }

        /// <summary>Test stub for cancel()</summary>
        [PexMethod]
        public void cancelTest([PexAssumeUnderTest]AccountManager target)
        {
            target.cancel();
            // TODO: add assertions to method AccountManagerTest.cancelTest(AccountManager)
        }

        /// <summary>Test stub for createUser()</summary>
        [PexMethod]
        public void createUserTest([PexAssumeUnderTest]AccountManager target)
        {
            target.createUser();
            // TODO: add assertions to method AccountManagerTest.createUserTest(AccountManager)
        }

        /// <summary>Test stub for registerUser()</summary>
        [PexMethod]
        public void registerUserTest([PexAssumeUnderTest]AccountManager target)
        {
            target.registerUser();
            // TODO: add assertions to method AccountManagerTest.registerUserTest(AccountManager)
        }
    }
}
