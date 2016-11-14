using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.DifficultySettings;
using Assets;
using Assets.Scripts;
using Assets.Scripts.Scoring;
namespace Assets.Scripts
{
    public class Credits : MonoBehaviour
    {

        /// <summary>
        /// Indicates whether or not the menu item specifies to go to the main menu
        /// </summary>
        public bool MainMenuFlag;

        void OnMouseUp()
        {
            if (MainMenuFlag)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
            }

        }
    }
}
