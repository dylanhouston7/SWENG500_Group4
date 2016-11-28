using System.Collections.Generic;
using System.Security;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Account;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Account.Tests
{
    public partial class AccountDataSaveLoadTest
    {

[TestMethod]
[PexGeneratedBy(typeof(AccountDataSaveLoadTest))]
[PexRaisedException(typeof(SecurityException))]
public void SaveAccountDataTestThrowsSecurityException346()
{
    this.SaveAccountDataTest((string)null, (AccountData)null);
}

[TestMethod]
[PexGeneratedBy(typeof(AccountDataSaveLoadTest))]
[PexRaisedException(typeof(SecurityException))]
public void SaveAccountDataTestThrowsSecurityException411()
{
    this.SaveAccountDataTest("", (AccountData)null);
}

[TestMethod]
[PexGeneratedBy(typeof(AccountDataSaveLoadTest))]
[PexRaisedException(typeof(SecurityException))]
public void SaveAccountDataTestThrowsSecurityException140()
{
    AccountData s0 = new AccountData();
    s0.gamerTag = (string)null;
    s0.password = (string)null;
    s0.firstName = (string)null;
    s0.lastName = (string)null;
    s0.email = (string)null;
    s0.birthday = default(DateTime);
    s0.achievements = (List<Achievement>)null;
    s0.completedMazes = (List<AccountCompletedMaze>)null;
    this.SaveAccountDataTest((string)null, s0);
}
    }
}
