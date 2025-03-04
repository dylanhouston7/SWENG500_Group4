using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGeneratorTest.Tests
{
    /// <summary>This class contains parameterized unit tests for MazeGenerator</summary>
    [TestClass]
    [PexClass(typeof(global::MazeGenerator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MazeGeneratorTest
    {
    }
}
