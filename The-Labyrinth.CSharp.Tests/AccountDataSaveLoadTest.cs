using System;
using Account;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Account.Tests
{
    /// <summary>This class contains parameterized unit tests for AccountDataSaveLoad</summary>
    [TestClass]
    [PexClass(typeof(AccountDataSaveLoad))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AccountDataSaveLoadTest
    {

        /// <summary>Test stub for LoadAccountData(String, AccountData&amp;)</summary>
        [PexMethod]
        public void LoadAccountDataTest(string path, ref AccountData account_data)
        {
            AccountDataSaveLoad.LoadAccountData(path, ref account_data);
            // TODO: add assertions to method AccountDataSaveLoadTest.LoadAccountDataTest(String, AccountData&)
        }

        /// <summary>Test stub for SaveAccountData(String, AccountData)</summary>
        [PexMethod]
        public void SaveAccountDataTest(string path, AccountData account_data)
        {
            AccountDataSaveLoad.SaveAccountData(path, account_data);
            // TODO: add assertions to method AccountDataSaveLoadTest.SaveAccountDataTest(String, AccountData)
        }
    }
}
