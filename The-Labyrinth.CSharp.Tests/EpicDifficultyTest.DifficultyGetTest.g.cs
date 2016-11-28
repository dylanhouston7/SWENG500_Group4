using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.DifficultySettings;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Assets.Scripts.DifficultySettings.Tests
{
    public partial class EpicDifficultyTest
    {

[TestMethod]
[PexGeneratedBy(typeof(EpicDifficultyTest))]
public void DifficultyGetTest55501()
{
    EpicDifficulty epicDifficulty;
    DifficultyEnum i;
    epicDifficulty = EpicDifficultyFactory.Create();
    i = this.DifficultyGetTest(epicDifficulty);
    Assert.AreEqual<DifficultyEnum>(DifficultyEnum.EPIC, i);
    Assert.IsNotNull((object)epicDifficulty);
    Assert.AreEqual<DifficultyEnum>(DifficultyEnum.EPIC, epicDifficulty.Difficulty);
    Assert.AreEqual<string>
        ("You won\'t win in this mode.", epicDifficulty.Description);
    Assert.AreEqual<string>("EPIC", epicDifficulty.DifficultyString);
    Assert.AreEqual<int>(5, epicDifficulty.GetScoringMultiplier);
}
    }
}
