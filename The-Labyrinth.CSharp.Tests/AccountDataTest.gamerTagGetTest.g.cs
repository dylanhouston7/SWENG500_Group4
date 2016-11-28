using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
    public partial class AccountDataTest
    {

[TestMethod]
[PexGeneratedBy(typeof(AccountDataTest))]
public void gamerTagGetTest161()
{
    string s;
    AccountData s0 = new AccountData();
    s0.gamerTag = (string)null;
    s0.password = (string)null;
    s0.firstName = (string)null;
    s0.lastName = (string)null;
    s0.email = (string)null;
    s0.birthday = default(DateTime);
    s0.achievements = (List<Achievement>)null;
    s0.completedMazes = (List<AccountCompletedMaze>)null;
    s = this.gamerTagGetTest(s0);
    Assert.AreEqual<string>((string)null, s);
    Assert.IsNotNull((object)s0);
    Assert.AreEqual<string>((string)null, s0.gamerTag);
    Assert.AreEqual<string>((string)null, s0.password);
    Assert.AreEqual<string>((string)null, s0.firstName);
    Assert.AreEqual<string>((string)null, s0.lastName);
    Assert.AreEqual<string>((string)null, s0.email);
    Assert.AreEqual<int>(1, s0.birthday.Day);
    Assert.AreEqual<DayOfWeek>(DayOfWeek.Monday, s0.birthday.DayOfWeek);
    Assert.AreEqual<int>(1, s0.birthday.DayOfYear);
    Assert.AreEqual<int>(0, s0.birthday.Hour);
    Assert.AreEqual<DateTimeKind>(DateTimeKind.Unspecified, s0.birthday.Kind);
    Assert.AreEqual<int>(0, s0.birthday.Millisecond);
    Assert.AreEqual<int>(0, s0.birthday.Minute);
    Assert.AreEqual<int>(1, s0.birthday.Month);
    Assert.AreEqual<int>(0, s0.birthday.Second);
    Assert.AreEqual<int>(1, s0.birthday.Year);
    Assert.IsNull(s0.achievements);
    Assert.IsNull(s0.completedMazes);
}
    }
}
