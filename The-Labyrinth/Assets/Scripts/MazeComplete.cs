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
        TextMesh initialScore = GameObject.Find("InitialScoreNumber").GetComponent<TextMesh>();
        TextMesh hintsNumber = GameObject.Find("HintsNumber").GetComponent<TextMesh>();
        TextMesh difficultyMultiplier = GameObject.Find("DifficultyMultiplierNumber").GetComponent<TextMesh>();
        TextMesh overallScoreNumber = GameObject.Find("OverallScoreNumber").GetComponent<TextMesh>();

        initialScore.text = "to-do";

        if (GameContext.m_context.score.hintShown)
        {
            // TO-DO: Add constant in here
            hintsNumber.text = "-5000";
        }

        else
        {
            hintsNumber.text = "-0";
        }

        difficultyMultiplier.text = string.Format("{0} (X{1})", GameContext.m_context.difficulty.DifficultyString, GameContext.m_context.difficulty.GetScoringMultiplier);
        overallScoreNumber.text = GameContext.m_context.score.score.ToString();
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
