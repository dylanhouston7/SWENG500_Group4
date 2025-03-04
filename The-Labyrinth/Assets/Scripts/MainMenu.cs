﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets;

/// <summary>
/// Class that contains the links from the main menu to other screens
/// </summary>
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game
    /// </summary>
    public bool StartFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show achievements
    /// </summary>
    public bool AchievementFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the credits
    /// </summary>
    public bool CreditFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the maze generator
    /// </summary>
    public bool CreateMazeFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the import maze screen
    /// </summary>
    public bool ImportMazeFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the import settings screen
    /// </summary>
    public bool SettingsFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the register user screen
    /// </summary>
    public bool registerFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the register user screen
    /// </summary>
    public bool exitFlag;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
	
	}

    /// <summary>
    /// Handles mouse selection
    /// </summary>
    void OnMouseUp()
    {
        if (StartFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.DifficultyScene); 
        }

        else if (CreateMazeFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MazeGeneratorScene);
        }

        else if (ImportMazeFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MazeImportScene);
        }

        else if (CreditFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.CreditsScene);
        }

        else if (SettingsFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.SettingsScene);
        }

        else if (registerFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.RegisterScene);
        }

        else if (exitFlag)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        // Mute Music
        if (Input.GetKeyDown(KeyCode.F10))
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
