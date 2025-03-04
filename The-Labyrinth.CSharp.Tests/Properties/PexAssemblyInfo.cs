using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("Assembly-CSharp")]
[assembly: PexInstrumentAssembly("FileDialogs")]
[assembly: PexInstrumentAssembly("Assembly-CSharp-firstpass")]
[assembly: PexInstrumentAssembly("UnityEditor")]
[assembly: PexInstrumentAssembly("UnityEngine")]
[assembly: PexInstrumentAssembly("UnityEngine.UI")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "FileDialogs")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Assembly-CSharp-firstpass")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEditor")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.UI")]

