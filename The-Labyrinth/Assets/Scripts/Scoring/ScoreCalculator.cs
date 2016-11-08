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
        const int bazeMazeScore = 50000;

        /// <summary>
        /// Calculates the Score for a completed maze
        /// </summary>
        /// <param name="difficulty">The difficulty level of the maze just completed</param>
        /// <param name="mazeCompletionTimeInSeconds">The number of seconds it took to complete the maze</param>
        /// <param name="hintCount">The number of hints that the user requested</param>
        /// <returns>An object with the players' score</returns>
        public static ScoreContainer CalculateScore(IDifficulty difficulty, int mazeCompletionTimeInSeconds, int hintCount)
        {
            ScoreContainer scoreContainer = new ScoreContainer();

            // Figure out how many points to deduct based on how long it took for the user to complete the maze.
            int timeDeduction = mazeCompletionTimeInSeconds * 16;

            // Subtract the time deduction from the baze maze score
            int score = bazeMazeScore - timeDeduction;
            scoreContainer.InitialScore = score;

            // Reward the user with a scoring multiplier based on difficulty level
            int scoringMultipler = difficulty.GetScoringMultiplier;
            score = score * scoringMultipler;

            // Severely punish the user if they used the hint system...
            int scorePenalty = 5000 * hintCount;
            score = score - hintCount;
            

            if (score < 0)
            {
                score = 0;
            }

            scoreContainer.TotalScore = score;
            scoreContainer.Difficulty = difficulty.DifficultyString;
            scoreContainer.HintCount = hintCount;
            scoreContainer.HintPenalty = scorePenalty;
            return scoreContainer;
        }
    }
}
