using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeStructure;
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
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void GetRandomMazeTest50801()
{
    EpicDifficulty epicDifficulty;
    Maze2D maze2D;
    epicDifficulty = EpicDifficultyFactory.Create();
    maze2D = this.GetRandomMazeTest(epicDifficulty);
}
    }
}
