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
        UpdateScoreLabels();
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MazeLevelScene);
        }

        else if (MainMenuFlag)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
        }
    }

    /// <summary>
    /// Updates all the score labels with information pertaining to the just completed maze.
    /// </summary>
    void UpdateScoreLabels()
    {
        TextMesh initialScore = GameObject.Find("InitialScoreNumber").GetComponent<TextMesh>();
        TextMesh hintsNumber = GameObject.Find("HintsNumber").GetComponent<TextMesh>();
        TextMesh difficultyMultiplier = GameObject.Find("DifficultyMultiplierNumber").GetComponent<TextMesh>();
        TextMesh overallScoreNumber = GameObject.Find("OverallScoreNumber").GetComponent<TextMesh>();

        if (GameContext.m_context.score.HintCount > 0)
        {
            hintsNumber.text = string.Format("-{0}", GameContext.m_context.score.HintPenalty);
        }

        else
        {
            hintsNumber.text = "-0";
        }

        initialScore.text = GameContext.m_context.score.InitialScore.ToString();
        difficultyMultiplier.text = string.Format("{0} (X{1})", GameContext.m_context.difficulty.DifficultyString, GameContext.m_context.difficulty.GetScoringMultiplier);
        overallScoreNumber.text = GameContext.m_context.score.TotalScore.ToString();
    }
}
