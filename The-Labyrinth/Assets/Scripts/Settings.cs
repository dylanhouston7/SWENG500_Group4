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
    public class Settings : MonoBehaviour
    {
        /// Indicates whether or not the menu item specifies to go to the next maze
        /// </summary>
        public bool NextMazeFlag;

        /// <summary>
        /// Indicates whether or not the menu item specifies to go to the main menu
        /// </summary>
        public bool MainMenuFlag;

        public bool MusicOffFlag;

        public bool MusicOnFlag;

        public void MusicOff()
        {
            AudioListener.pause = true;
        }

        public void MusicOn()
        {
            AudioListener.pause = false;
        }

        void OnMouseUp()
        {
            if (MainMenuFlag)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
            }
            else if (MusicOffFlag)
            {
                MusicOff();
                Debug.Log("Music Off Button Clicked");
            }

            else if (MusicOnFlag)
            {
                MusicOn();
            }

        }
    }
}
