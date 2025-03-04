using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;
using System.Collections;

namespace PlayerControllerTest.Tests
{
    /// <summary>This class contains parameterized unit tests for PlayerController</summary>
    [TestClass]
    [PexClass(typeof(global::PlayerController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlayerControllerTest
    {
    }
}
