using System.Security;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace PlayerTest.Tests
{
    public partial class PlayerTest
    {

[TestMethod]
[PexGeneratedBy(typeof(global::PlayerTest.Tests.PlayerTest))]
[PexRaisedException(typeof(SecurityException))]
public void ConstructorTestThrowsSecurityException591()
{
    global::Player player;
    player = this.ConstructorTest();
}
    }
}
