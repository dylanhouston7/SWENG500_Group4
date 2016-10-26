// File: DifficultyMenu.cs
// Description: Script for the DifficultyMenu
// Author: Dylan Houston

using UnityEngine;
using System.Collections;
using Assets;
using Assets.Scripts.DifficultySettings;
using UnityEngine.UI;

/// <summary>
/// Class that contains the links from the difficulty menu to other screens
/// </summary>
public class DifficultyMenu : MonoBehaviour
{

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game in easy mode
    /// </summary>
    public bool EasyFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game in medium mode
    /// </summary>
    public bool MediumFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game in hard mode
    /// </summary>
    public bool HardFlag;

    /// <summary>
    /// Indicates whether or not the menu item specifies to start the game in epic mode
    /// </summary>
    public bool EpicFlag;

    /// <summary>
    /// The Description TextMesh object
    /// </summary>
    TextMesh Description;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /// <summary>
    /// Updates the description text on the Difficulty Menu, based on what difficulty level is hovered over.
    /// </summary>
    void OnMouseEnter()
    {
        IDifficulty difficulty = GetDifficulty();
        Description = GameObject.Find("Description").GetComponent<TextMesh>();
        Description.text = difficulty.Description;
    }

    /// <summary>
    /// Retrieves the difficulty based on menu selectiopn
    /// </summary>
    /// <returns>The difficulty level</returns>
    IDifficulty GetDifficulty()
    {
        IDifficulty difficulty;

        // IMPROVE: Is there a better way to handle this?

        if (EasyFlag)
        {
            difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.EASY);
        }

        else if (MediumFlag)
        {
            difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.MEDIUM);
        }

        else if (HardFlag)
        {
            difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.HARD);
        }

        else if (EpicFlag)
        {
            difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.EPIC);
        }

        else
        {
            throw new System.Exception("Invalid difficulty given");
        }

        return difficulty;
    }

    /// <summary>
    /// Handles the mouse up (click) event
    /// </summary>
    void OnMouseUp()
    {
        IDifficulty difficulty = GetDifficulty();
        GameContext.m_context.difficulty = difficulty;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
    }
}
