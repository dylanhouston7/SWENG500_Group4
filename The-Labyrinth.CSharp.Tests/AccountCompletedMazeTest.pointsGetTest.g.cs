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
    public partial class AccountCompletedMazeTest
    {

[TestMethod]
[PexGeneratedBy(typeof(AccountCompletedMazeTest))]
public void pointsGetTest689()
{
    int i;
    AccountCompletedMaze s0 = new AccountCompletedMaze();
    s0.maze_guid = default(Guid);
    s0.dateAchieved = default(DateTime);
    s0.points = 0;
    i = this.pointsGetTest(s0);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)s0);
    Assert.AreEqual<int>(1, s0.dateAchieved.Day);
    Assert.AreEqual<DayOfWeek>(DayOfWeek.Monday, s0.dateAchieved.DayOfWeek);
    Assert.AreEqual<int>(1, s0.dateAchieved.DayOfYear);
    Assert.AreEqual<int>(0, s0.dateAchieved.Hour);
    Assert.AreEqual<DateTimeKind>(DateTimeKind.Unspecified, s0.dateAchieved.Kind);
    Assert.AreEqual<int>(0, s0.dateAchieved.Millisecond);
    Assert.AreEqual<int>(0, s0.dateAchieved.Minute);
    Assert.AreEqual<int>(1, s0.dateAchieved.Month);
    Assert.AreEqual<int>(0, s0.dateAchieved.Second);
    Assert.AreEqual<int>(1, s0.dateAchieved.Year);
    Assert.AreEqual<int>(0, s0.points);
}
    }
}
