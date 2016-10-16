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

    void OnMouseEnter()
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

        Description = GameObject.Find("Description").GetComponent<TextMesh>();
        Description.text = difficulty.Description;
    }

        /// <summary>
        /// Handles the mouse up (click) event
        /// </summary>
    void OnMouseUp()
    {
        if (EasyFlag)
        {
            GameContext.m_context.m_gameDifficulty = DifficultyEnum.EASY;
        }

        else if (MediumFlag)
        {
            GameContext.m_context.m_gameDifficulty = DifficultyEnum.MEDIUM;
        }

        else if (HardFlag)
        {
            GameContext.m_context.m_gameDifficulty = DifficultyEnum.HARD;
        }

        else if (EpicFlag)
        {
            GameContext.m_context.m_gameDifficulty = DifficultyEnum.EPIC;
        }

        // TODO: Look at logic in GameManager to reflect difficulty and to set scoring algorithm
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
    }
}
