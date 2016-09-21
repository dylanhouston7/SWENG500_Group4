using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that contains the links from the main menu to other screens
/// </summary>
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game
    /// </summary>
    public bool isStart;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show achievements
    /// </summary>
    public bool isAchievements;

    /// <summary>
    /// Indicates whether or not the menu item specifies to show the credits
    /// </summary>
    public bool isCredits;

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
        if (isStart)
        {
            // Initial maze. 
            // TODO: Replace with a screen that lets the user select the difficulty of the maze.
            SceneManager.LoadScene(1);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
	
	}
}
