// File: Score.cs
// Description: A class to use to calculate the score for a user
// Author: Dylan Houston

using Assets.Scripts.DifficultySettings;

namespace Assets.Scripts.Scoring
{
    /// <summary>
    /// A class to use to calculate the score for a user
    /// </summary>
    public static class ScoreCalculator
    {
        /// <summary>
        /// The baze score for all mazes
        /// </summary>
        const int bazeMazeScore = 10000;

        public static Score CalculateScore(IDifficulty difficulty, int mazeCompletionTimeInSeconds, bool hintShown)
        {
            Score scoreContainer = new Score();

            // Figure out how many points to deduct based on how long it took for the user to complete the maze.
            int timeDeduction = mazeCompletionTimeInSeconds * 10;

            // Subtract the time deduction from the baze maze score
            int score = bazeMazeScore - timeDeduction;

            // Reward the user with a scoring multiplier based on difficulty level
            int scoringMultipler = difficulty.GetScoringMultiplier;
            score = score * scoringMultipler;

            // Severely punish the user if they used the hint system...
            if (hintShown)
            {
                score = score - 5000;
            }

            if (score < 0)
            {
                score = 0;
            }

            scoreContainer.score = score;
            scoreContainer.difficulty = difficulty.DifficultyString;
            scoreContainer.hintShown = hintShown;
            return scoreContainer;
        }
    }
}
