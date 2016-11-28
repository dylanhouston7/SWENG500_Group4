using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.DifficultySettings;
using Assets.Scripts.Scoring;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Assets.Scripts.Scoring.Tests
{
    public partial class ScoreCalculatorTest
    {

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void CalculateScoreTestThrowsNullReferenceException492()
{
    ScoreContainer scoreContainer;
    scoreContainer = this.CalculateScoreTest((IDifficulty)null, 0, 0);
}

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
public void CalculateScoreTest770()
{
    HardDifficulty hardDifficulty;
    ScoreContainer scoreContainer;
    hardDifficulty = new HardDifficulty();
    scoreContainer = this.CalculateScoreTest((IDifficulty)hardDifficulty, 0, 0);
    Assert.IsNotNull((object)scoreContainer);
    Assert.AreEqual<int>(50000, scoreContainer.InitialScore);
    Assert.AreEqual<int>(150000, scoreContainer.TotalScore);
    Assert.AreEqual<string>("HARD", scoreContainer.Difficulty);
    Assert.AreEqual<int>(0, scoreContainer.HintCount);
    Assert.AreEqual<int>(0, scoreContainer.HintPenalty);
}

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
public void CalculateScoreTest556()
{
    HardDifficulty hardDifficulty;
    ScoreContainer scoreContainer;
    hardDifficulty = new HardDifficulty();
    scoreContainer = this.CalculateScoreTest((IDifficulty)hardDifficulty, 900, 128);
    Assert.IsNotNull((object)scoreContainer);
    Assert.AreEqual<int>(35600, scoreContainer.InitialScore);
    Assert.AreEqual<int>(0, scoreContainer.TotalScore);
    Assert.AreEqual<string>("HARD", scoreContainer.Difficulty);
    Assert.AreEqual<int>(128, scoreContainer.HintCount);
    Assert.AreEqual<int>(640000, scoreContainer.HintPenalty);
}

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
public void CalculateScoreTest713()
{
    MediumDifficulty mediumDifficulty;
    ScoreContainer scoreContainer;
    mediumDifficulty = new MediumDifficulty();
    scoreContainer = this.CalculateScoreTest((IDifficulty)mediumDifficulty, 0, 0);
    Assert.IsNotNull((object)scoreContainer);
    Assert.AreEqual<int>(50000, scoreContainer.InitialScore);
    Assert.AreEqual<int>(100000, scoreContainer.TotalScore);
    Assert.AreEqual<string>("MEDIUM", scoreContainer.Difficulty);
    Assert.AreEqual<int>(0, scoreContainer.HintCount);
    Assert.AreEqual<int>(0, scoreContainer.HintPenalty);
}

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
public void CalculateScoreTest328()
{
    EasyDifficulty easyDifficulty;
    ScoreContainer scoreContainer;
    easyDifficulty = new EasyDifficulty();
    scoreContainer = this.CalculateScoreTest((IDifficulty)easyDifficulty, 0, 0);
    Assert.IsNotNull((object)scoreContainer);
    Assert.AreEqual<int>(50000, scoreContainer.InitialScore);
    Assert.AreEqual<int>(50000, scoreContainer.TotalScore);
    Assert.AreEqual<string>("EASY", scoreContainer.Difficulty);
    Assert.AreEqual<int>(0, scoreContainer.HintCount);
    Assert.AreEqual<int>(0, scoreContainer.HintPenalty);
}

[TestMethod]
[PexGeneratedBy(typeof(ScoreCalculatorTest))]
public void CalculateScoreTest562()
{
    EpicDifficulty epicDifficulty;
    ScoreContainer scoreContainer;
    epicDifficulty = EpicDifficultyFactory.Create();
    scoreContainer = this.CalculateScoreTest((IDifficulty)epicDifficulty, 0, 0);
    Assert.IsNotNull((object)scoreContainer);
    Assert.AreEqual<int>(50000, scoreContainer.InitialScore);
    Assert.AreEqual<int>(250000, scoreContainer.TotalScore);
    Assert.AreEqual<string>("EPIC", scoreContainer.Difficulty);
    Assert.AreEqual<int>(0, scoreContainer.HintCount);
    Assert.AreEqual<int>(0, scoreContainer.HintPenalty);
}
    }
}
