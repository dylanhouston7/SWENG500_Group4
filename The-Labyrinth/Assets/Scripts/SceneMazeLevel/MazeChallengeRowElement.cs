using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

using Assets;

public class MazeChallengeRowElement : MonoBehaviour
{
    // Public GameObject References
    public Text m_textMazeName;

    // Private Variables
    int m_mazeRefIndex;


    // ********************************************
    // Unity Methods
    // ********************************************

    /// <summary>
    /// Unity Method for initialization of GameObject called first
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Awake()
    {
        m_textMazeName.text = "";

        m_mazeRefIndex = -1;
    }

    // ********************************************
    // Public Methods
    // ********************************************

    /// <summary>
    /// Method used to initialize the maze challenge row element
    /// </summary>
    /// <param name="mazeRefIndex">Index in the GameContext maze set that the reference maze is stored</param>
    /// <param name="mazeRef">Reference maze that the maze challenge row element represents</param>
    public void Initialize(int mazeRefIndex, MazeStructure.Maze2D mazeRef)
    {
        // Set the Maze Reference Index
        m_mazeRefIndex = mazeRefIndex;

        // Set the Maze Name
        m_textMazeName.text = mazeRef.Name;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    // ********************************************
    // Public EventSystem Handler Methods
    // ********************************************

    /// <summary>
    /// Method used to start the referenced GameContext maze
    /// </summary>
    public void StartMaze()
    {
        if (m_mazeRefIndex >= 0)
        {
            // Set the GameContext Active Maze Index to the maze referenced by this maze level row element
            GameContext.m_context.m_activeMazeIndex = m_mazeRefIndex;

            GameContext.m_context.m_isActiveMazeChallenge = true;

            // Load the Main Scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
        }
    }
}

