﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    /// Points to the main scene-- the first maze
    /// </summary>
    private const string MainMenuScene = "MainScene";

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
	
	}

    /// <summary>
    /// 
    /// </summary>
    void OnMouseUp()
    {
        if (StartFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenuScene);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
	
	}
}
