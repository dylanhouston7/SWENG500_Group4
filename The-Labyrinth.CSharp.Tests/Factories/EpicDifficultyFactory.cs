using Assets.Scripts.DifficultySettings;
using System;
using Microsoft.Pex.Framework;

namespace Assets.Scripts.DifficultySettings
{
    /// <summary>A factory for Assets.Scripts.DifficultySettings.EpicDifficulty instances</summary>
    public static partial class EpicDifficultyFactory
    {
        /// <summary>A factory for Assets.Scripts.DifficultySettings.EpicDifficulty instances</summary>
        [PexFactoryMethod(typeof(EpicDifficulty))]
        public static EpicDifficulty Create()
        {
            EpicDifficulty epicDifficulty = new EpicDifficulty();
            return epicDifficulty;

            // TODO: Edit factory method of EpicDifficulty
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
