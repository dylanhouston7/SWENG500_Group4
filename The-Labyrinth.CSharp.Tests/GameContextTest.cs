using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameContextTests.Tests
{
    /// <summary>This class contains parameterized unit tests for GameContext</summary>
    [TestClass]
    [PexClass(typeof(global::GameContext))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GameContextTest
    {
    }
}
