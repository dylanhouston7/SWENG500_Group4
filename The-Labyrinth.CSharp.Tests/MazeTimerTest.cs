using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeTimerTests.Tests
{
    /// <summary>This class contains parameterized unit tests for MazeTimer</summary>
    [TestClass]
    [PexClass(typeof(global::MazeTimer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MazeTimerTest
    {
    }
}
