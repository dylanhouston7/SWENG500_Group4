using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DifficultyMenuTests.Tests
{
    /// <summary>This class contains parameterized unit tests for DifficultyMenu</summary>
    [TestClass]
    [PexClass(typeof(global::DifficultyMenu))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DifficultyMenuTest
    {
    }
}
