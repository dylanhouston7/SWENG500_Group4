// File: MazeComplete.cs
// Description: Scripts for the Maze Complete (score) screen
// Author: Dylan Houston


using UnityEngine;
using System.Collections;
using Assets;

/// <summary>
/// Sets of scripts for the Maze Complete screen
/// </summary>
public class MazeComplete : MonoBehaviour
{
    /// <summary>
    /// Indicates whether or not the menu item specifies to go to the next maze
    /// </summary>
    public bool NextMazeFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to go to the main menu
    /// </summary>
    public bool MainMenuFlag;


    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /// <summary>
    /// Handles mouse selection
    /// </summary>
    void OnMouseUp()
    {
        if (NextMazeFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
        }

        else if (MainMenuFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
        }
    }
}
