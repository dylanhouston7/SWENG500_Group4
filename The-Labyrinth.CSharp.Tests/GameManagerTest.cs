using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameManagerTests.Tests
{
    /// <summary>This class contains parameterized unit tests for GameManager</summary>
    [TestClass]
    [PexClass(typeof(global::GameManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GameManagerTest
    {
    }
}
